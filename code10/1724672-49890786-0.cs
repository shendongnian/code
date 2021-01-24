    using System;
    using System.Timers;
    
    public class Clock
    {
        private static Timer aTimer;
        private TimeSpan time;
        public Clock()
        {
            // Initialize the time to zero.
            time = TimeSpan.Zero;
            
            // Create a timer and set a one-second interval.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;
    
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
    
            // Start the timer.
            aTimer.Enabled = true;
        }
    
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            time = time.Add(TimeSpan.FromSeconds(1));
        }
    }
