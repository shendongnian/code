    class Program
    {
        static void Main(string[] args)
        {
            // warming up
            CreateNumbersYield(1);
            CreateNumbersList(1, true);
            Measure(null, () => { });
            // testing
            var size = 1000000;
            Measure("Yield", () => CreateNumbersYield(size));
            Measure("Yield + ToList", () => CreateNumbersYield(size).ToList());
            Measure("List", () => CreateNumbersList(size, false));
            Measure("List + Set initial capacity", () => CreateNumbersList(size, true));
            Console.ReadLine();
        }
        static void Measure(string testName, Action action)
        {
            var sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            Console.WriteLine($"{testName} completed in {sw.Elapsed}");
        }
        static IEnumerable<int> CreateNumbersYield(int size) //for yield
        {
            for (int i = 0; i < size; i++)
            {
                yield return i;
            }
        }
        static IEnumerable<int> CreateNumbersList(int size, bool setInitialCapacity) //for list
        {
            var list = setInitialCapacity ? new List<int>(size) : new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
