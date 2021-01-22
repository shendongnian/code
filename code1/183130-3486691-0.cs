    using System;
    
    public class PortChat
    {
        public static System.Timers.Timer _timer;
        public static void Main()
        {
    
            _timer = new System.Timers.Timer();
            _timer.Interval = 5000;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true;
            Console.ReadKey();
        }
    
        static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Do Your loop
        }
    }
