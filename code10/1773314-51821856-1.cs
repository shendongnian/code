     class Program
    {
        private static bool running = true;
        private static bool stop = false;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CancelKeyPress += myHandler;
            while (!stop)
            {
	                if (running)
	                {
		                Console.WriteLine("Hello World!");		                
	                } 
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("Exiting ...");
        }
        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
            running = false;
            Console.WriteLine("Do you wish to resume... Y/N \n");
            var resume = Console.ReadLine();
            if (resume == "Y")
            {
                running = true;
            }
            else
            {
                stop = true;
            }
        }
    }
