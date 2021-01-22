        /// <summary>
        /// Merge a pair of ordered lists
        /// </summary>
        public static IEnumerable<T> Merge<T>(IEnumerable<T> aList, IEnumerable<T> bList)
            where T:IComparable<T>
        {
            var a = aList.GetEnumerator();
            bool aOK = a.MoveNext();
            foreach (var b in bList)
            {
                while (aOK && a.Current.CompareTo(b) <= 0) {yield return a.Current; aOK = a.MoveNext();}
                yield return b;
            }
            // And anything left in a
            while (aOK) { yield return a.Current; aOK = a.MoveNext(); }
        }
        /// <summary>
        /// Merge lots of sorted lists
        /// </summary>
        public static IEnumerable<T> Merge<T>(IEnumerable<IEnumerable<T>> listOfLists)
            where T : IComparable<T>
        {
            int n = listOfLists.Count();
            if (n < 2) 
                return listOfLists.FirstOrDefault();
            else
                return Merge (Merge(listOfLists.Take(n/2)), Merge(listOfLists.Skip(n/2)));
        }
    public static void Main(string[] args)
    {
        var sample = Enumerable.Range(1, 5).Select((i) => Enumerable.Range(i, i+5).Select(j => string.Format("Test {0:00}", j)));
        Console.WriteLine("Merged:");
        foreach (var result in Merge(sample))
        {
            Console.WriteLine("\t{0}", result);
        }
