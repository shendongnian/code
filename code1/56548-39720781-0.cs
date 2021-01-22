    static void Main(string[] args)
        {
            Console.WriteLine("Generating list...");
            List<string> list = GenerateTestList(1000000);
            var s = string.Empty;
            Stopwatch sw;
            Stopwatch sw2;
            List<long> existsTimes = new List<long>();
            List<long> anyTimes = new List<long>();
            Console.WriteLine("Executing...");
            for (int j = 0; j < 1000; j++)
            {
                sw = Stopwatch.StartNew();
                if (!list.Exists(o => o == "0123456789012"))
                {
                    sw.Stop();
                    existsTimes.Add(sw.ElapsedTicks);
                }
            }
            for (int j = 0; j < 1000; j++)
            {
                sw2 = Stopwatch.StartNew();
                if (!list.Exists(o => o == "0123456789012"))
                {
                    sw2.Stop();
                    anyTimes.Add(sw2.ElapsedTicks);
                }
            }
            long existsFastest = existsTimes.Min();
            long anyFastest = anyTimes.Min();
            Console.WriteLine(string.Format("Fastest Exists() execution: {0} ticks\nFastest Any() execution: {1} ticks", existsFastest.ToString(), anyFastest.ToString()));
            Console.WriteLine("Benchmark finished. Press any key.");
            Console.ReadKey();
        }
    
        public static List<string> GenerateTestList(int count)
        {
            var list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                Random r = new Random();
                int it = r.Next(0, 100);
                list.Add(new string('s', it));
            }
            return list;
        }
