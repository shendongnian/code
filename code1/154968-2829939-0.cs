    internal class Program
    {
        static void Main(string[] args)
        {
            var grouper = new DuplicateGrouper<string>();
            var result = grouper.GroupByDuplicate(new[] {"a", "b", "b", "b", "c", "c", "d"});
            foreach (var r in result)
            {
                Console.WriteLine("Group".PadRight(16, '='));
                foreach (var s in r)
                    Console.WriteLine(s);
            }
        }
    }
    internal class DuplicateGrouper<T>
    {
        T CurrentKey;
        IEnumerator<T> Itr;
        bool More;
        public IEnumerable<IEnumerable<T>> GroupByDuplicate(IEnumerable<T> src)
        {
            Itr = src.GetEnumerator();
            More = Itr.MoveNext();
            while (More)
                yield return GetDuplicates();
        }
        IEnumerable<T> GetDuplicates()
        {
            CurrentKey = Itr.Current;
            while (CurrentKey.Equals(Itr.Current) && More)
            {
                yield return Itr.Current;
                More = Itr.MoveNext();
            }
        }
    }
