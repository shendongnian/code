        private static bool paused;
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CancelKeyPress += myHandler;
            while (true)
            {
                if (!paused)
                    Console.WriteLine("Hello World!");
                System.Threading.Thread.Sleep(1000);
            }
        }
        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Do you want to exit?");
            var answer = Console.ReadLine();
            args.Cancel = answer != "y";
        }
