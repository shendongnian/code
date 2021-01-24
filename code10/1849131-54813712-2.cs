    [MemoryDiagnoser]
    public class Tests
    {
        private List<String> minusLIST = new List<string>(100000);
        private List<String> plusLIST = new List<string>(200000);
        [IterationSetup]
        public void IterationSetup()
        {
            plusLIST.Clear();
            minusLIST.Clear();
            //Add 3 million elements
            for (double i = 0; i < 100000; i += 1)
            {
                plusLIST.Add(i + ",awb/aje" + " - " + "ddfas/asa" + " - " + "asoo/qwa");
            }
            for (double i = 1; i < 200000; i += 1)
            {
                minusLIST.Add("-" + i + ",awb/aje" + " - " + "ddfas/asa" + " - " + "asoo/qwa");
            }
        }
        [Benchmark]
        public List<String> OPSort()
        {
            plusLIST = plusLIST.OrderBy(i => double.Parse(i.Split(',')[0])).ToList(); plusLIST.Reverse();
            minusLIST = minusLIST.OrderBy(i => double.Parse(i.Split(',')[0].TrimStart('-'))).ToList();
            plusLIST.AddRange(minusLIST);
            return plusLIST;
        }
        [Benchmark]
        public List<String> OPSortByDescendingLazy()
        {
            var result = new List<string>(plusLIST.Count + minusLIST.Count);
            result.AddRange(plusLIST.OrderByDescending(i => int.Parse(i.Split(',')[0])));
            result.AddRange(minusLIST.OrderBy(i => int.Parse(i.Split(',')[0].TrimStart('-'))));
            return result;
        }
        [Benchmark]
        public List<String> SlightlyParallelSort()
        {
            var result = new List<string>(plusLIST.Count + minusLIST.Count);
            var t1 = Task.Run(() => plusLIST.OrderByDescending(i => int.Parse(i.Split(',')[0])));
            var t2 = Task.Run(() => minusLIST.OrderBy(i => int.Parse(i.Split(',')[0].TrimStart('-'))));
            Task.WaitAll(t1, t2);
            result.AddRange(t1.Result);
            result.AddRange(t2.Result);
            return result;
        }
        [Benchmark]
        public List<String> ParallelSort()
        {
            var result = new List<string>(plusLIST.Count + minusLIST.Count);
            var t1 = Task.Run(() => plusLIST.AsParallel().OrderByDescending(i => int.Parse(i.Split(',')[0])));
            var t2 = Task.Run(() => minusLIST.AsParallel().OrderBy(i => int.Parse(i.Split(',')[0].TrimStart('-'))));
            Task.WaitAll(t1, t2);
            result.AddRange(t1.Result);
            result.AddRange(t2.Result);
            return result;
        }
        private static readonly Regex splitRegex = new Regex(@"^(\d+)");
        private static readonly Regex splitWithMinusRegex = new Regex(@"^-(\d+)");
        // To test the suggestion from @PanagiotisKanavos 
        [Benchmark]
        public List<String> RegexSort()
        {
            plusLIST = plusLIST.OrderBy(i => double.Parse(splitRegex.Match(i).Groups[1].Value)).ToList(); plusLIST.Reverse();
            minusLIST = minusLIST.OrderBy(i => double.Parse(splitWithMinusRegex.Match(i).Groups[1].Value)).ToList();
            plusLIST.AddRange(minusLIST);
            return plusLIST;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Tests>();
            Console.WriteLine("========= DONE! ============");
            Console.ReadLine();
        }
    }
