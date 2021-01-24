    static void Main(string[] args)
        {
            var timer = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = 100,
                Enabled = true
            };
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
            Console.ReadKey();
        }
        private static void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Console.WriteLine("do stuff on a interval");
        }
