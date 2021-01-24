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
            Test(randomList, MaxOccurrences1);
            Test(randomList, MaxOccurrences2);
            Console.WriteLine("=============");
            Console.WriteLine("Full List");
            Test(randomList, Original1);
            Test(randomList, Original2);
            Test(randomList, AsParallel1);
            Test(randomList, AsParallel2);
            Test(randomList, AsParallel3);
            Console.ReadLine();
        }
        private static void Test(List<int> data, Action<List<int>> method)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            method(data);
            watch.Stop();
            Console.WriteLine($"{method.Method.Name}: {watch.ElapsedMilliseconds}");
        }
        private static void Original1(List<int> integers)
        {
            integers?.GroupBy(number => number)
                .OrderByDescending(group => group.Count())
                .Select(k => new NumberCount(k.Key, k.Count()))
                .ToList();
        }
        private static void Original2(List<int> integers)
        {
            integers?.GroupBy(number => number)
                .Select(k => new NumberCount(k.Key, k.Count()))
                .OrderByDescending(x => x.Occurrences)
                .ToList();
        }
        private static void AsParallel1(List<int> integers)
        {
            integers?.GroupBy(number => number)
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
        private static void AsParallel3(List<int> integers)
        {
            integers?.AsParallel()
                .GroupBy(number => number)
                .Select(k => new NumberCount(k.Key, k.Count())) //Grap result, before sort
                .OrderByDescending(x => x.Occurrences) //sort after result
                .ToList();
        }
        private static void MaxOccurrences1(List<int> integers)
        {
            integers?.AsParallel()
                .GroupBy(number => number)
                .GroupBy(x => x.Count())
                .OrderByDescending(x => x.Key)
                .FirstOrDefault()?
                .ToList()
                .Select(k => new NumberCount(k.Key, k.Count()))
                .ToList();
        }
        private static void MaxOccurrences2(List<int> integers)
        {
            integers?.AsParallel()
                .GroupBy(x => x)//group numbers, key is number, count is count
                .Select(k => new NumberCount(k.Key, k.Count()))
                .GroupBy(x => x.Occurrences)//group by Occurrences, key is Occurrences, value is result
                .OrderByDescending(x => x.Key) //sort
                .FirstOrDefault()? //the first one is result
                .ToList();
        }
        private static void ConcurrentDictionary1(List<int> integers)
        {
            ConcurrentDictionary<int, int> result = new ConcurrentDictionary<int, int>();
            integers?.ForEach(x => { result.AddOrUpdate(x, 1, (key, old) => old + 1); });
            result.OrderByDescending(x => x.Value).ToList();
        }
        private static void ConcurrentDictionary2(List<int> integers)
        {
            ConcurrentDictionary<int, int> result = new ConcurrentDictionary<int, int>();
            integers?.AsParallel().ForAll(x => { result.AddOrUpdate(x, 1, (key, old) => old + 1); });
            result.OrderByDescending(x => x.Value).ToList();
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
