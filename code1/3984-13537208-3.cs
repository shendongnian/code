    static Random rnd = new Random();
    public static int GetRandomIndex<T>(this ICollection<T> source)
    {
        return rnd.Next(source.Count);
    }
    public static T GetRandom<T>(this IList<T> source)
    {
        return source[source.GetRandomIndex()];
    }
    static void AddRandomly<T>(this ICollection<T> toCol, IList<T> fromList, int count)
    {
        while (toCol.Count < count)
            toCol.Add(fromList.GetRandom());
    }
    public static Dictionary<int, T> ToIndexedDictionary<T>(this IEnumerable<T> lst)
    {
        return lst.ToIndexedDictionary(t => t);
    }
    public static Dictionary<int, T> ToIndexedDictionary<S, T>(this IEnumerable<S> lst, 
                                                               Func<S, T> valueSelector)
    {
        int index = -1;
        return lst.ToDictionary(t => ++index, valueSelector);
    }
