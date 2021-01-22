        public static bool IsDebuggingEnabled { get; set; }
        static void Main(string[] args)
        {
            for (int j = 0; j <= 10; j++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i <= 15000; i++)
                {
                    Log(GetDebugMessage);
                    if (i % 1000 == 0) IsDebuggingEnabled = !IsDebuggingEnabled;
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
            Console.ReadLine();
            for (int j = 0; j <= 10; j++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i <= 15000; i++)
                {
                    if (IsDebuggingEnabled) GetDebugMessage();
                    if (i % 1000 == 0) IsDebuggingEnabled = !IsDebuggingEnabled;
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
            Console.ReadLine();
        }
        public static string GetDebugMessage()
        {
            StringBuilder sb = new StringBuilder(100);
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                sb.Append(rnd.Next(100, 150));
            }
            return sb.ToString();
        }
        public static void Log(Func<string> getMessage)
        {
            if (IsDebuggingEnabled)
            {
                getMessage();
            }
        }
