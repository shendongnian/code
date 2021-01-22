    using System;
    using System.Timers;
    public class Timer1
    {
        private static Timer aTimer = new System.Timers.Timer(10000);
        public static void Main()
        {
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }
        // Specify what you want to happen when the Elapsed event is 
        // raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        }
    }
