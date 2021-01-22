    internal class Program
    {
        static void Main(string[] args)
        {
            var result = new[] { "a", "b", "b", "b", "c", "c", "d" }.Partition();
            foreach (var r in result)
            {
                Console.WriteLine("Group".PadRight(16, '='));
                foreach (var s in r)
                    Console.WriteLine(s);
            }
        }
    }
    internal static class PartitionExtension
    {
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> src)
        {
            var grouper = new DuplicateGrouper<T>();
            return grouper.GroupByDuplicate(src);
        }
    }
    internal class DuplicateGrouper<T>
    {
        T CurrentKey;
        IEnumerator<T> Itr;
        bool More;
        public IEnumerable<IEnumerable<T>> GroupByDuplicate(IEnumerable<T> src)
        {
            using(Itr = src.GetEnumerator())
            {
                More = Itr.MoveNext();
                while (More)
                    yield return GetDuplicates();
            }
        }
        IEnumerable<T> GetDuplicates()
        {
            CurrentKey = Itr.Current;
            while (More && CurrentKey.Equals(Itr.Current))
            {
                yield return Itr.Current;
                More = Itr.MoveNext();
            }
        }
    }
