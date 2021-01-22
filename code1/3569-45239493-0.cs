    static class Extensions
    {
        public static IEnumerable<(int, T)> Enumerate<T>(
            this IEnumerable<T> input,
            int start = 0
        )
        {
            int i = start;
            foreach (var t in input)
            {
                yield return (i++, t);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = new string[]
            {
                "Alpha",
                "Bravo",
                "Charlie",
                "Delta"
            };
    
            foreach (var (i, t) in s.Enumerate())
            {
                Console.WriteLine($"{i}: {t}");
            }
        }
    }
