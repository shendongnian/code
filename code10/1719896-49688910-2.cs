    public class CustomerComparer : IComparer<KeyValuePair<int, ColorType>>
    {
        private List<ColorType> orderedLetters = new List<ColorType>() { ColorType.White, ColorType.Yellow, ColorType.Red };
        public int Compare(KeyValuePair<int, ColorType> str1, KeyValuePair<int, ColorType> str2)
        {
            return orderedLetters.IndexOf(str1.Value) - orderedLetters.IndexOf(str2.Value);
        }
    }
    public enum ColorType
    {
        Red,
        Yellow,
        White
    }
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new Dictionary<int, ColorType>()
            {
                {1, ColorType.Red},
                {4, ColorType.Yellow},
                {5, ColorType.Red},
                {6, ColorType.Yellow},
                {8, ColorType.White},
                {9, ColorType.Red},
                {10, ColorType.Yellow},
                {13, ColorType.White}
            };
            var sorted = unsorted.OrderBy(x => x, new CustomerComparer());
            foreach (var entry in sorted)
            {
                Console.WriteLine("{0}: {1}", entry.Key, entry.Value);
            }
            Console.ReadKey();
        }
    }
