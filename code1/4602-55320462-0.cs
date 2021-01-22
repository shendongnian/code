    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the answer? (5 secs.)");
            try
            {
                var answer = ConsoleReadLine.ReadLine(5000);
                Console.WriteLine("Answer is: {0}", answer);
            }
            catch
            {
                Console.WriteLine("No answer");
            }
            Console.ReadKey();
        }
    }
    class ConsoleReadLine
    {
        private static string inputLast;
        private static Thread inputThread = new Thread(inputThreadAction) { IsBackground = true };
        private static AutoResetEvent inputGet = new AutoResetEvent(false);
        private static AutoResetEvent inputGot = new AutoResetEvent(false);
        static ConsoleReadLine()
        {
            inputThread.Start();
        }
        private static void inputThreadAction()
        {
            while (true)
            {
                inputGet.WaitOne();
                inputLast = Console.ReadLine();
                inputGot.Set();
            }
        }
        // omit the parameter to read a line without a timeout
        public static string ReadLine(int timeout = Timeout.Infinite)
        {
            if (timeout == Timeout.Infinite)
            {
                return Console.ReadLine();
            }
            else
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                while (stopwatch.ElapsedMilliseconds < timeout && !Console.KeyAvailable) ;
                if (Console.KeyAvailable)
                {
                    inputGet.Set();
                    inputGot.WaitOne();
                    return inputLast;
                }
                else
                {
                    throw new TimeoutException("User did not provide input within the timelimit.");
                }
            }
        }
    }
