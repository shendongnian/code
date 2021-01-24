        public static void Main(string[] args)
        {
            var stopwatch1 = new Stopwatch();
            var dictionaryTest = GetDictionary(1000);
            stopwatch1.Start();
            var results = dictionaryTest.Values.Select(x => x.Position).ToList();
            stopwatch1.Stop();
            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            var results2 = dictionaryTest.Select(obj => obj.Value.Position).ToList();
            stopwatch2.Stop();
            var stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            var myList = new List<double>();
            foreach (var pair in dictionaryTest)
            {
                myList.Add(pair.Value.Position);
            }
            stopwatch3.Stop();
            Console.WriteLine("results1: " + stopwatch1.Elapsed);
            Console.WriteLine("results2: " + stopwatch2.Elapsed);
            Console.WriteLine("results3: " + stopwatch3.Elapsed);
            Console.Read();
        }
        public static Dictionary<long, MyUser> GetDictionary(int numberOfRows)
        {
            var d = new Dictionary<long, MyUser>();
            for (int i = 0; i < numberOfRows; i++)
            {
                d.Add(1000 + i, new MyUser { Age = 10 + i, Position = 100.01 + i });
            }
            return d;
        }
