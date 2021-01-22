    public static string Coalesce(this string str, params string[] strings)
    {
        return (new[] {str})
            .Concat(strings)
            .FirstOrDefault(s => !string.IsNullOrEmpty(s));
    }
