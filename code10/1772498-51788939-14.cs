    class Program
    {
        static void Main(string[] args)
        {
            const int listSize = 3000000;
            var rnd = new Random();
            var randomList = Enumerable.Range(1, listSize).OrderBy(e => rnd.Next()).ToList();
            // the code that you want to measure comes here
            Console.WriteLine(randomList.Count);
            Console.WriteLine("MaxOccurrences only");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MaxOccurrences1(randomList);
            watch.Stop();
            Console.WriteLine("MaxOccurrences1: " + watch.ElapsedMilliseconds);
            watch = System.Diagnostics.Stopwatch.StartNew();
            MaxOccurrences2(randomList);
            watch.Stop();
            Console.WriteLine("MaxOccurrences2: " + watch.ElapsedMilliseconds);
            Console.WriteLine("=============");
            Console.WriteLine("Full List");
            watch = System.Diagnostics.Stopwatch.StartNew();
            Original1(randomList);
            watch.Stop();
            Console.WriteLine("Original1: " + watch.ElapsedMilliseconds);
            watch = System.Diagnostics.Stopwatch.StartNew();
            Original2(randomList);
            watch.Stop();
            Console.WriteLine("Original2: " + watch.ElapsedMilliseconds);
            watch = System.Diagnostics.Stopwatch.StartNew();
            ConcurrentDictionary1(randomList);
            watch.Stop();
            Console.WriteLine("ConcurrentDictionary1: " + watch.ElapsedMilliseconds);
            watch = System.Diagnostics.Stopwatch.StartNew();
            ConcurrentDictionary2(randomList);
            watch.Stop();
            Console.WriteLine("ConcurrentDictionary2: " + watch.ElapsedMilliseconds);
            watch = System.Diagnostics.Stopwatch.StartNew();
            AsParallel1(randomList);
            watch.Stop();
            Console.WriteLine("AsParallel1: " + watch.ElapsedMilliseconds);
            watch = System.Diagnostics.Stopwatch.StartNew();
            AsParallel2(randomList);
            watch.Stop();
            Console.WriteLine("AsParallel2: " + watch.ElapsedMilliseconds);
            watch = System.Diagnostics.Stopwatch.StartNew();
            AsParallel3(randomList);
            watch.Stop();
            Console.WriteLine("AsParallel3: " + watch.ElapsedMilliseconds);
            watch.Stop();
            Console.ReadLine();
        }
        private static List<NumberCount> Original1(List<int> integers)
        {
            return integers?.GroupBy(number => number)
                .OrderByDescending(group => group.Count())
                .Select(k => new NumberCount(k.Key, k.Count()))
                .ToList();
        }
        private static List<NumberCount> Original2(List<int> integers)
        {
            return integers?.GroupBy(number => number)
                .Select(k => new NumberCount(k.Key, k.Count()))
                .OrderByDescending(x => x.Occurrences)
                .ToList();
        }
        private static List<NumberCount> AsParallel1(List<int> integers)
        {
            return integers?.GroupBy(number => number)
                .AsParallel() //each group will be count by a CPU unit
                .Select(k => new NumberCount(k.Key, k.Count())) //Grap result, before sort
                .OrderByDescending(x => x.Occurrences) //sort after result
                .ToList();
        }
        private static void AsParallel2(List<int> integers)
        {
            integers?.AsParallel()
                .GroupBy(number => number)
                .Select(k => new
                {
                    Key = k.Key,
                    Occurrences = k.Count()
                }) //Grap result, before sort
                .OrderByDescending(x => x.Occurrences) //sort after result
                .ToList();
        }
        private static List<NumberCount> AsParallel3(List<int> integers)
        {
            return integers?.AsParallel()
                .GroupBy(number => number)
                .Select(k => new NumberCount(k.Key, k.Count())) //Grap result, before sort
                .OrderByDescending(x => x.Occurrences) //sort after result
                .ToList();
        }
        private static List<NumberCount> MaxOccurrences1(List<int> integers)
        {
            return integers?.AsParallel()
                .GroupBy(number => number) //group numbers, key is number, count is Occurrences
                .GroupBy(x => x.Count()) //group by count, key is Occurrences, value is result
                .OrderByDescending(x => x.Key)
                .FirstOrDefault()? //the first the your result
                .ToList()//get MaxOccurrences list
                .Select(k => new NumberCount(k.Key, k.Count())) //Grap result, before sort
                .ToList();
        }
        private static List<NumberCount> MaxOccurrences2(List<int> integers)
        {
            return integers?.AsParallel()
                .GroupBy(number => number)
                .Select(k => new NumberCount(k.Key, k.Count()))
                .GroupBy(x=>x.Occurrences)
                .OrderByDescending(x => x.Key)
                .FirstOrDefault()?
                .ToList();
        }
        private static List<KeyValuePair<int, int>> ConcurrentDictionary1(List<int> integers)
        {
            ConcurrentDictionary<int, int> result = new ConcurrentDictionary<int, int>();
            integers?.ForEach(x => { result.AddOrUpdate(x, 1, (key, old) => old + 1); });
            return result.OrderByDescending(x => x.Value).ToList();
        }
        private static List<KeyValuePair<int, int>> ConcurrentDictionary2(List<int> integers)
        {
            ConcurrentDictionary<int, int> result = new ConcurrentDictionary<int, int>();
            integers?.AsParallel().ForAll(x => { result.AddOrUpdate(x, 1, (key, old) => old + 1); });
            return result.OrderByDescending(x => x.Value).ToList();
        }
    }
    public class NumberCount
    {
        public int Value;
        public int Occurrences;
        public NumberCount(int value, int occurrences)
        {
            Value = value;
            Occurrences = occurrences;
        }
    }
