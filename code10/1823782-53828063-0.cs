    [MemoryDiagnoser]
    public class Test
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Test>();
        }
        public int Size = 100000;
        [Benchmark]
        public int ConsumeYield()
        {
            var sum = 0;
            foreach (var x in CreateNumbersYield()) sum += x;
            return sum;
        }
        [Benchmark]
        public int ConsumeList()
        {
            var sum = 0;
            foreach (var x in CreateNumbersList()) sum += x;
            return sum;
        }
        public IEnumerable<int> CreateNumbersYield() //for yield
        {
            for (int i = 0; i < Size; i++) yield return i;
        }
        public IEnumerable<int> CreateNumbersList() //for list
        {
            var list = new List<int>();
            for (int i = 0; i < Size; i++) list.Add(i);
            return list;
        }
    }
