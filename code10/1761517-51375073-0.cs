    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(PullFrame);
            timer.Interval = 300000; // 5 minutes in milliseconds
            timer.Enabled = true;
            Console.ReadKey(); // Prevents program from exiting.
        }
        public static void PullFrame(object source, ElapsedEventArgs evArgs)
        {
            // Do something every 5 mins.
        }
    }
