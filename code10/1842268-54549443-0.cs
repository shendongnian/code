    public IEnumerable<T> ReflectionSearch<T>(IEnumerable<T> items, string propName, string value, StringComparer comparer = null)
    {
        var t = typeof(T).GetProperty(propName);
        if (t == null) throw new Exception("No such prop");
        comparer = comparer ?? StringComparer.OrdinalIgnoreCase;
        foreach (var item in items)
        {
            var v = t.GetValue(item)?.ToString();
            if (comparer.Equals(v, value))
                yield return item;
        }
    }
