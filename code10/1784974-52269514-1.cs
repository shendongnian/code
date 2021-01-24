    public class DiscordWallTimer
    {
            public static bool TimerOn;
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
                if (TimerOn == true)
                {
                    Program.SendAlertDiscord();
                }
                else
                {
                		MinecraftClient.ChatBots.DiscordWallTimer.wallTimer.Stop();    // <- stop the timer if TimerOn is false
                }
            }
    }
