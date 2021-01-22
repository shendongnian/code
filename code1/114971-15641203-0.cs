    public static class Ext
    {
        public static void Sort<T>(this ObservableCollection<T> src)
            where T : IComparable<T>
        {
            // Some preliminary safety checks
            if(src == null) throw new ArgumentNullException("src");
            if(!src.Any()) return;
            
            // N for the select,
            // + ~ N log N, assuming "smart" sort implementation on the OrderBy
            // Total: N log N + N (est)
            var indexedPairs = src
                .Select((item,i) => Tuple.Create(i, item))
                .OrderBy(tup => tup.Item2);
            // N for another select
            var postIndexedPairs = indexedPairs
                .Select((item,i) => Tuple.Create(i, item.Item1, item.Item2));
            // N for a loop over every element
            var pairEnum = postIndexedPairs.GetEnumerator();
            pairEnum.MoveNext();
            for(int idx = 0; idx < src.Count; idx++, pairEnum.MoveNext())
            {
                src.RemoveAt(pairEnum.Current.Item1);
                src.Insert(idx, pairEnum.Current.Item3);            
            }
            // (very roughly) Estimated Complexity: 
            // N log N + N + N + N
            // == N log N + 3N
        }
    }
