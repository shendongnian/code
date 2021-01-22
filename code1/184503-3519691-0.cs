    // Nice method's name, @Dan Tao
    public static bool ContainsAny(this string value, params string[] params)
    {
        return params.Any(p => value.Compare(p) > 0);
        // or
        return params.Any(p => value.Contains(p));
    }
