using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace YeatDownloader
{
    internal class Downloader
    {
        private static bool downloading = false; // Add a flag to track downloading status

        static async Task Main(string[] args)
        {
            // Start a separate thread to update the console title
            Thread titleUpdaterThread = new Thread(UpdateConsoleTitle);
            titleUpdaterThread.Start();

            Console.Title = $"Yeat downloader v1 - {DateTime.Now.ToString("HH:mm:ss")}";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Yeat Downloader v1");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Select what you want to download:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Official songs");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2. Unreleased / Leaked songs");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("3. Remixes");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4. All songs");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please select a valid option!");
                Console.ResetColor();
            }

            // Define the download folders based on the user's choice
            string officialSongsFolder = "Official songs";
            string unreleasedSongsFolder = "Unreleased songs";
            string remixesFolder = "Remixes";

            // Create the download folders if they don't exist
            Directory.CreateDirectory(officialSongsFolder);
            Directory.CreateDirectory(unreleasedSongsFolder);
            Directory.CreateDirectory(remixesFolder);

            if (choice == 1)
            {
                // Download official songs
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Downloading Yeat's Official songs");
                Console.WriteLine();

                await DownloadOfficialSongs(officialSongsFolder);
            }
            else if (choice == 2)
            {
                // Download unreleased/leaked songs
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Downloading Yeat's Unreleased & leaked songs");
                Console.WriteLine();

                await DownloadUnreleasedSongs(unreleasedSongsFolder);
            }
            else if (choice == 3)
            {
                // Download remixes
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Downloading Remixes of Yeat's songs");
                Console.WriteLine();

                await DownloadRemixes(remixesFolder);
            }
            else if (choice == 4)
            {
                // Download all songs
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Downloading every Yeat song");
                Console.WriteLine();

                await DownloadOfficialSongs(officialSongsFolder);
                await DownloadUnreleasedSongs(unreleasedSongsFolder);
                await DownloadRemixes(remixesFolder);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nDownloads completed. Press any key to exit.");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static async Task DownloadOfficialSongs(string folder)
        {
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1154927484433879050/y2mate.com_-_Yeat_Straight_2_Ella_Official_Audio.mp3", Path.Combine(folder, "Straight 2 ella.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1154980072411902003/y2mate.com_-_Summrs_Yeat_Count_Up_Prod_trgc.mp3", Path.Combine(folder, "Count up.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1154982531632988222/y2mate.com_-_YEAT_OUT_THE_WAY_BUT_THE_INTRO_IS_BEAUTIFUL_AF.mp3", Path.Combine(folder, "Out the way.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155014342211813387/y2mate.com_-_bigger_then_everything_Official_Audio.mp3", Path.Combine(folder, "Bigger then everything.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155014815325106276/y2mate.com_-_My_wrist_with_Young_Thug_Official_Audio.mp3", Path.Combine(folder, "My wrist.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155015126924136478/y2mate.com_-_Shmunk_feat_YoungBoy_Never_Broke_Again_Official_Audio.mp3", Path.Combine(folder, "Shmunk.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155015497943887972/y2mate.com_-_How_it_go_Official_Audio_1.mp3", Path.Combine(folder, "How it go.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155016824820355072/y2mate.com_-_Demon_tied_Official_Audio.mp3", Path.Combine(folder, "Dëmon tied.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155017169088815104/y2mate.com_-_Back_up_Official_Audio.mp3", Path.Combine(folder, "Back up.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155017654499815504/y2mate.com_-_Shhhh_Official_Audio_1.mp3", Path.Combine(folder, "Shhhh.mp3"));

            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021444800057374/y2mate.com_-_Holy_1_Official_Audio.mp3", Path.Combine(folder, "Holy 1.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021445118840832/y2mate.com_-_Talk_Official_Audio.mp3", Path.Combine(folder, "Talk.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021445475344384/y2mate.com_-_Wat_it_feel_lyke_Official_Audio.mp3", Path.Combine(folder, "Wat it feel lyke.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155014342211813387/y2mate.com_-_bigger_then_everything_Official_Audio.mp3", Path.Combine(folder, "Bigger then everything.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021445810884678/y2mate.com_-_Krank_Official_Audio.mp3", Path.Combine(folder, "Krank.mp3"));

            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021446423257109/y2mate.com_-_Come_on_Official_Audio.mp3", Path.Combine(folder, "Come on.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021471802982430/y2mate.com_-_Up_off_X_Official_Audio.mp3", Path.Combine(folder, "Up off X.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021472138530956/y2mate.com_-_Woa_Official_Audio.mp3", Path.Combine(folder, "Woa.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155017654499815504/y2mate.com_-_Shhhh_Official_Audio_1.mp3", Path.Combine(folder, "Shhhh.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021472478277662/y2mate.com_-_Back_home_Official_Audio.mp3", Path.Combine(folder, "Back home.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021472826392656/y2mate.com_-_Flawless_feat_Lil_Uzi_Vert_Official_Audio.mp3", Path.Combine(folder, "Flawless.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021473140969532/y2mate.com_-_Killin_em_Official_Audio.mp3", Path.Combine(folder, "Killin em.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021473543630899/y2mate.com_-_Cant_stop_it_Official_Audio.mp3", Path.Combine(folder, "Cant stop it.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021473879162981/y2mate.com_-_Got_it_all_Official_Audio.mp3", Path.Combine(folder, "Got it all.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021474218913833/y2mate.com_-_System_Official_Audio.mp3", Path.Combine(folder, "System.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021501230219316/y2mate.com_-_7_nightz_Official_Audio.mp3", Path.Combine(folder, "7 nightz.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021501691600986/y2mate.com_-_Now_feat_Luh_Geeky_Official_Audio.mp3", Path.Combine(folder, "Now.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021502194929705/y2mate.com_-_Sum_2_do_Official_Audio.mp3", Path.Combine(folder, "Sum 2 do.mp3"));  
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021502576590878/y2mate.com_-_Bettr_0ff_Official_Audio.mp3", Path.Combine(folder, "Bettr 0ff.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021502874394624/y2mate.com_-_Heavyweight_Official_Audio.mp3", Path.Combine(folder, "Heavyweight.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021503176396851/y2mate.com_-_Split_Official_Audio.mp3", Path.Combine(folder, "Split.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021503499337820/y2mate.com_-_Type_money_Official_Audio_1.mp3", Path.Combine(folder, "Type money.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021503788752946/y2mate.com_-_Rav3_p4rty_feat_Kranky_Kranky_Official_Audio.mp3", Path.Combine(folder, "Rav3 p4rty.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021525477498940/y2mate.com_-_No_more_talk_Official_Audio.mp3", Path.Combine(folder, "No more talk.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021525917908992/y2mate.com_-_Nun_id_change_Official_Audio.mp3", Path.Combine(folder, "Nun id change.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021526286999663/y2mate.com_-_Bad_bend_DeMON_Official_Audio.mp3", Path.Combine(folder, "Bad bend DeMON.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021526605774848/y2mate.com_-_Myself_Official_Audio.mp3", Path.Combine(folder, "Myself.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154923770381877359/1155021526932918332/y2mate.com_-_Slamm_Official_Audio.mp3", Path.Combine(folder, "Slamm.mp3"));

            // add any links to the downloads in that exact format
        }

        private static async Task DownloadUnreleasedSongs(string folder)
        {
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926764229918791/1154980759610863626/y2mate.com_-_Yeat_Liv_on_a_Moon.mp3", Path.Combine(folder, "Liv on a moon.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926764229918791/1154981186578427944/Yeat_-_Sidewayz_2.mp3", Path.Combine(folder, "Sidewayz 2.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926764229918791/1154982024759750746/y2mate.com_-_Yeat_HAB_High_as_a_Btch_Extended_Snippet.mp3", Path.Combine(folder, "High as a bitch.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926764229918791/1154982309351669830/y2mate.com_-_Yeat_X_unreleased_yeat_yeatunreleased_unreleased_kankan.mp3", Path.Combine(folder, "X.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926764229918791/1154982449449799712/y2mate.com_-_Yeat_Fun.mp3", Path.Combine(folder, "Fun.mp3"));

            // add any links to the downloads in that exact format
        }

        private static async Task DownloadRemixes(string folder)
        {
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926983709458564/1154980054468657232/y2mate.com_-_yeat_x_septembersrich_trendy_way_ripcore.mp3", Path.Combine(folder, "Trendy way (ripcore).mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926983709458564/1154980707987357697/y2mate.com_-_YEAT_JUS_BETTER_Guitar_remix.mp3", Path.Combine(folder, "Jus better guitar remix.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926983709458564/1154981402924822608/y2mate.com_-_Yeat_God_Speed_feat_Playboi_Carti_Prod_Posty.mp3", Path.Combine(folder, "God speed.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926983709458564/1154981407479832636/y2mate.com_-_YEAT_Get_Busy_2_prod_spriiteice.mp3", Path.Combine(folder, "Get Busy 2.mp3"));
            
            await DownloadFile("https://cdn.discordapp.com/attachments/1154926983709458564/1154982371158929521/y2mate.com_-_Yeat_x_prtmotherluv_How_It_Go_Guitar_Remix.mp3", Path.Combine(folder, "How it go guitar remix.mp3"));

            // add any links to the downloads in that exact format
        }

        private static async Task DownloadFile(string url, string filePath)
        {
            downloading = true; // Set downloading to true when starting a download
            using (var client = new WebClient())
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Downloading \n\n{Path.GetFileName(filePath)}...");
                    Console.ResetColor();

                    // Get the full path and display it in the console
                    string fullPath = Path.GetFullPath(filePath);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"\nLocation:\n\n{fullPath}");

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    // Track progress while downloading
                    client.DownloadProgressChanged += (sender, e) =>
                    {
                        Console.Title = $"Yeat downloader v1 - Downloading {Path.GetFileNameWithoutExtension(filePath)} - {DateTime.Now.ToString("HH:mm:ss")} - Current Progress : {e.ProgressPercentage}%";
                    };

                    await client.DownloadFileTaskAsync(new Uri(url), filePath);
                    Console.WriteLine($"\n{Path.GetFileName(filePath)} downloaded successfully.\n");
                    Console.ResetColor();

                    downloading = false; // Set downloading to false when the download is complete
                }
                catch (Exception ex)    
                {
                    Console.WriteLine($"Error downloading {Path.GetFileName(filePath)}: {ex.Message}");
                    downloading = false; // Set downloading to false in case of an error
                }
            }
        }

        private static void UpdateConsoleTitle()
        {
            while (true)
            {
                if (!downloading)
                {
                    Console.Title = $"Yeat downloader v1 - {DateTime.Now.ToString("HH:mm:ss")}";
                }

                // Sleep for a short duration to avoid high CPU usage
                Thread.Sleep(100); // Sleep for 1 second
            }
        }
    }
}
