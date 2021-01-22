    class Program
    {
        static void Main(string[] args)
        {
            int interval = 5 * 1000; //milliseconds
            int duration = 10 * 60 * 1000; //milliseconds
    
            intervalTimer = new System.Timers.Timer(interval);
            durationTimer = new System.Timers.Timer(duration);
    
            intervalTimer.Elapsed += new System.Timers.ElapsedEventHandler(intervalTimer_Elapsed);
            durationTimer.Elapsed += new System.Timers.ElapsedEventHandler(durationTimer_Elapsed);
    
            intervalTimer.Start();
            durationTimer.Start();
        }
    
        static void durationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            intervalTimer.Stop();
            durationTimer.Stop();
        }
    
        static void intervalTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //call your method
        }
    
        private static System.Timers.Timer intervalTimer;
        private static System.Timers.Timer durationTimer;
    }
