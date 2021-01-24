     public static void Check()
            {
               // the first time walltimer doesnt exist
               if (MinecraftClient.ChatBots.DiscordWallTimer.wallTimer != null)
               {
                    MinecraftClient.ChatBots.DiscordWallTimer.wallTimer.Stop();
               }
                Program.StartTimer();
            }
    public class DiscordWallTimer
    {
            public static System.Timers.Timer wallTimer;
    
            internal static Task StartTimer()
            {
                Console.WriteLine("Wall timer has started");
    
                wallTimer = new Timer()
                {
                    Interval = 5*1000,
                    AutoReset = true,
                    Enabled = true                     // <- keep True
                };
                wallTimer.Elapsed += OnTimerTicked;
    
                return Task.CompletedTask;
            }
            private static void OnTimerTicked(object sender, ElapsedEventArgs e)
            {
                Program.SendAlertDiscord();
            }
    }
