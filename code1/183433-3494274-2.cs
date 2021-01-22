    lngList.Sort(new Comparison<Dictionary<int, Dictionary<string, string>>>(sortFunc));
    public int sortFunc(Dictionary<int, Dictionary<string, string>> a,
                        Dictionary<int, Dictionary<string, string>> b)
    {
        return First(a.Keys).CompareTo(First(b.Keys));
    }
    public static T First<T>(IEnumerable<T> source) {
        using (var e = source.GetEnumerator()) {
            if (!e.MoveNext())
                throw new InvalidOperationException("The collection is empty.");
            return e.Current;
        }
    }
