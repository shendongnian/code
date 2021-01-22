    class Program
    {
        private const int ElementCount = 10000000;
        static void Main(string[] args)
        {
            var str = generateString();
            var stopwatch = new Stopwatch();
      
            var list1 = new List<int>(ElementCount); 
            var list2 = new List<int>(ElementCount);
            var split = str.Split(';');
            stopwatch.Start();
            list1.AddRange(split
                              .Select(ToInt32OrNull) 
                              .Where(i => i != null) 
                              .Cast<int>());
            stopwatch.Stop();
            TimeSpan nonParallel = stopwatch.Elapsed;
            stopwatch.Restart();
            list2.AddRange(split
                              .AsParallel()
                              .Select(ToInt32OrNull)
                              .Where(i => i != null)
                              .Cast<int>());
            stopwatch.Stop();
            TimeSpan parallel = stopwatch.Elapsed;
            Debug.WriteLine("Non-parallel: {0}", nonParallel);
            Debug.WriteLine("Parallel: {0}", parallel);
        }
        private static String generateString()
        {
            var builder = new StringBuilder(1048576);
            var rnd = new Random();
            for (int i = 0; i < ElementCount; i++)
            {
                builder.Append(rnd.Next(99999));
                builder.Append(';');
            }
            builder.Length--;
            return builder.ToString();
        }
        static int? ToInt32OrNull(string s)
        {
            int value;
            return (Int32.TryParse(s, out value)) ? value : default(int?);
        } 
    }
