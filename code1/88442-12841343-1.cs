    public class timerClass
        {
            public timerClass()
            {
                System.Timers.Timer aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                // Set the Interval to 5 seconds.
                aTimer.Interval = 5000;
                aTimer.Enabled = true;
            }
            public static void OnTimedEvent(object source, ElapsedEventArgs e)
            {
              Console.Writeln("Welcome to TouchMagix");
            }
    }
