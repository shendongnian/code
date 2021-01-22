    public static IEnumerable<T> Merge<T>(this IEnumerable<IEnumerable<T>> self) 
        where T : IComparable<T>
    {
        var es = self.Select(x => x.GetEnumerator()).Where(e => e.MoveNext());
        var tmp = es.ToDictionary(e => e.Current);
        var dict = new SortedDictionary<T, IEnumerator<T>>(tmp);
        while (dict.Count > 0)
        {
            var key = dict.Keys.First();
            var cur = dict[key];
            dict.Remove(key);
            yield return cur.Current;
            if (cur.MoveNext())
                dict.Add(cur.Current, cur);                    
        }
    }
