    public class MyMassiv
    {
        private int[] _array;
        public int MaxElement => _array.Max();
        public int MinElement => _array.Min();
        public int Sum => _array.Sum();
        public double Average => _array.Average();
        public MyMassiv(int size = 10)
        {
            var rnd = new Random();
            _array = Enumerable.Range(0, size)
                .Select(i => rnd.Next(1000))
                .ToArray();
        }
        public IEnumerable<int> GetOddValues() => _array.Where(item => item % 2 != 0);
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyMassiv mm = new MyMassiv();
            Console.WriteLine(
                "Max: {0}, Min: {1}, Sum: {2}, Average: {3}",
                mm.MaxElement, 
                mm.MinElement, 
                mm.Sum,
                mm.Average);
            Console.Write("Odd Values: ");
            mm.GetOddValues()
               .ToList()
               .ForEach(item => Console.WriteLine(item));
            Console.ReadKey();
        }
    }
