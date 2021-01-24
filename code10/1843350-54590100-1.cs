    private static System.Timers.Timer timer = new System.Timers.Timer(2000);
            static void Main(string[] args)
            {
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
    
                // show instructions
                while (true)
                {
                   string answer = Console.ReadLine();
                    if (answer == "2") // check the answer somehow
                    {
                        timer.Stop(); // and restart the timer
                        timer.Start();
                        // show next question
                    }
                }
    
            }
    
            private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Console.WriteLine("Too late");
                timer.Elapsed -= Timer_Elapsed;
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
