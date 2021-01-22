    public class Program
    {
        delegate void SortMethod(double[] x, double[] y);
        private const int ARRAY_SIZE = 3000000;
        
        private static Random RandomNumberGenerator = new Random();
        private static double[] x = GenerateTestData(ARRAY_SIZE);
        private static double[] y = GenerateTestData(ARRAY_SIZE);
        private static double[] GenerateTestData(int count)
        {
            var data = new double[count];
            for (var i = 0; i < count; i++)
            {
                data[i] = RandomNumberGenerator.NextDouble();
            }
            return data;
        }
        private static void SortMethod1(double[] x, double[] y)
        {
            Array.Sort(x, y);
        }
        private static void SortMethod2(double[] x, double[] y)
        {
            IEnumerable<int> range = Enumerable.Range(0, x.Length);
            x = (from n in range orderby x[n] select y[n]).ToArray();
            y = (from n in range orderby x[n] select x[n]).ToArray();
        }
        private static void SortMethod3(double[] x, double[] y)
        {
            int[] x_index = 
                Enumerable.Range(0, x.Length).OrderBy(i => x[i]).ToArray();
            x = x_index.Select(i => x[i]).ToArray();
            y = x_index.Select(i => y[i]).ToArray();
        }
        private static void SortMethod4(double[] x, double[] y)
        {
            int[] range =
                Enumerable.Range(0, x.Length).OrderBy(i => x[i]).ToArray();
            var q = (
                from n in range
                orderby x[n]
                select new { First = x[n], Second = y[n] }).ToArray();
            x = q.Select(t => t.First).ToArray();
            y = q.Select(t => t.Second).ToArray();
        }
        private static void SortMethodPerformanceTest(SortMethod sortMethod)
        {
            double[] y_sorted = y.Clone() as double[];
            double[] x_sorted = x.Clone() as double[];
            var sw = new Stopwatch();
            
            sw.Start();
            sortMethod.Invoke(x_sorted, y_sorted);
            sw.Stop();
            
            Console.WriteLine(
                string.Format(
                    "{0} : {1}",
                    sortMethod.Method.Name,
                    sw.Elapsed));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("For array length : " + ARRAY_SIZE);
            Console.WriteLine("------------------------------");
            SortMethodPerformanceTest(SortMethod1);
            SortMethodPerformanceTest(SortMethod2);
            SortMethodPerformanceTest(SortMethod3);
            SortMethodPerformanceTest(SortMethod4);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
