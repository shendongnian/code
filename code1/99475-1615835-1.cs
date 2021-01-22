    if (stringName.In("foo", "bar", "baz"))
    {
    
    }
    // in an extension method class
    public static bool In(this string str, params string[] arr)
    {
        return arr.Contains(str);
    }
