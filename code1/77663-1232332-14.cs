    public static class AlexeyR
    {
        public static IEnumerable<T> AsReallyReadOnly<T>(this IEnumerable<T> source)
        {
            foreach (T t in source) yield return t;
        }
    }
    IEnumerable<int> f = a.AsReallyReadOnly(); // really?
    IList<int> g = f.AsWritable(); // apparently not!
    g.Add(8);
    Debug.Assert(a.Count == 8); // modified original again
