    using System;
    using System.Timers;
    
    public class Timer1
    {
        private static System.Timers.Timer aTimer;
    
        public static void Main()
        {
            // Normally, the timer is declared at the class level,
            // so that it stays in scope as long as it is needed.
            // If the timer is declared in a long-running method,  
            // KeepAlive must be used to prevent the JIT compiler 
            // from allowing aggressive garbage collection to occur 
            // before the method ends. (See end of method.)
            //System.Timers.Timer aTimer;
    
            // Create a timer with a ten second interval.
            aTimer = new System.Timers.Timer(10000);
    
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
    
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
    
            // If the timer is declared in a long-running method, use
            // KeepAlive to prevent garbage collection from occurring
            // before the method ends.
            //GC.KeepAlive(aTimer);
        }
    
        // Specify what you want to happen when the Elapsed event is 
        // raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        }
    }
    
    /* This code example produces output similar to the following:
    
    Press the Enter key to exit the program.
    The Elapsed event was raised at 5/20/2007 8:42:27 PM
    The Elapsed event was raised at 5/20/2007 8:42:29 PM
    The Elapsed event was raised at 5/20/2007 8:42:31 PM
    ...
     */
