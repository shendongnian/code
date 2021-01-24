     public enum ColorCodes
    {
        White = 1,
        Yellow = 2,
        Red = 3
    }
    class Program
    {
        /// <summary>
        /// Sorts dictionary by color enum int sequence
        /// </summary>
        /// <param name="toOrder"></param>
        /// <returns></returns>
        public static Dictionary<int, string> DictionarySorter(Dictionary<int, string> toOrder)
        {
            return toOrder.OrderBy(x => (int)(ColorCodes)Enum.Parse(typeof(ColorCodes), x.Value)).ToDictionary(x => x.Key, x => x.Value);
        }
        static void Main(string[] args)
        {
            Dictionary<int, string> unsortedColors = new Dictionary<int, string>();
            unsortedColors.Add(1, "Red");
            unsortedColors.Add(4, "Yellow");
            unsortedColors.Add(5, "Red");
            unsortedColors.Add(6, "Yellow");
            unsortedColors.Add(8, "White");
            unsortedColors.Add(9, "Red");
            unsortedColors.Add(10, "Yellow");
            unsortedColors.Add(13, "White");
          
            var sortedDic = DictionarySorter(unsortedColors);
            foreach (var entry in sortedDic)
            {
                Console.WriteLine(string.Format("{0} - {1}", entry.Key, entry.Value));
            }
            Console.Read();
        }
    }
