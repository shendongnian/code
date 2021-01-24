    public static T Method<T>(IEnumerable<T> source)
    {
        if (source is IList<T> list)
        {
            return Method(list);
        }
        else if (source is IReadonlyList<T> readOnly)
        {
            return Method(readOnly);
        }
        else
        {
            return Method(source.ToList() as IList<T>);
        }
    }
    private static T Method<T>(IReadOnlyList<T> list) { ... }
    private static T Method<T>(IList<T> list) { ... }
