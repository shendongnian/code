    class Program
    {
        private static volatile bool _s_stop = false;
        public static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            while (!_s_stop)
            {
                /* put real logic here */
                Console.WriteLine("still running at {0}", DateTime.Now);
                Thread.Sleep(3000);
            }
            Console.WriteLine("Graceful shut down code here...");
            //don't leave this...  demonstration purposes only...
            Console.ReadLine();
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            //you have 2 options here, leave e.Cancel set to false and just handle any
            //graceful shutdown that you can while in here, or set a flag to notify the other
            //thread at the next check that it's to shut down.  I'll do the 2nd option
            e.Cancel = true;
            _s_stop = true;
            Console.WriteLine("CancelKeyPress fired...");
        }
    }
