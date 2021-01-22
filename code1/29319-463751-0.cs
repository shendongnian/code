    class Program
    {
        static void Main(string[] args)
        {
            string[] text = new string[] { "val1", "val2", "val3", "val4", "val5" };
            int count = 0;
            foreach (string t in text.ContinuousLoopTo(30))
            {
                Console.WriteLine(count.ToString() + " = " + t);
                count++;
            }
            Console.ReadLine();
        }
    }
    public static class Extensions
    {
        public static IEnumerable<T> ContinuousLoopTo<T>(this IList<T> list, int number)
        {
            int loops = number / list.Count;
            int i = 0;
            while (i < loops)
            {
                i++;
                foreach (T item in list)
                {
                    yield return item;
                }
            }
            for (int j = 0; j < number % list.Count; j++)
            {
                yield return list[j];
            }
        }
    }
