    public static IEnumerable<string> ToCsv<T>(string separator, IEnumerable<T> objectlist)
    {
        FieldInfo[] fields = typeof(T).GetFields();
        yield return String.Join(separator, fields.Select(f => f.Name).ToArray());
        foreach (var o in objectlist)
        {
            yield return string.Join(separator, fields.Select(f=>(f.GetValue(o) ?? "").ToString()).ToArray());
        }
    }
