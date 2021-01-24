    public static T Method<T>(IEnumerable<T> source)
    {
        if (source is IReadonlyList<T> readOnly)
        {
            return Method(readOnly);
        }
        else if (source is List<T> list)
        {
            return Method(list);
        }
        else
        {
            return Method(source.ToList());
        }
    }
    private static T Method<T>(IReadOnlyList<T> list) { ... }
    private static T Method<T>(IList<T> list) { ... }
