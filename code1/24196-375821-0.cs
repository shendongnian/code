    class Program
    {
        static void Main(string[] args)
        {
            IList<int> l = new List<int>();
            l.Add(7);
            l.Add(11);
            l.Add(13);
            l.Add(17);
            foreach (var i in l.AsRandom())
                Console.WriteLine(i);
            Console.ReadLine();
        }
    }
    public static class MyExtensions
    {
        public static IEnumerable<T> AsRandom<T>(this IList<T> list)
        {
            int[] indexes = Enumerable.Range(0, list.Count).ToArray();
            Random generator = new Random();
            for (int i = 0; i < list.Count; ++i )
            {
                int position = generator.Next(i, list.Count);
                
                yield return list[indexes[position]];
                indexes[position] = indexes[i];
            }
        }
    }   
