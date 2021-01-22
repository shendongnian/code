    public static string DefaultIfEmpty(this string original,
                                        Func<string> defaultValueProvider)
    {
        return string.IsNullOrEmpty(original) ? defaultValueProvider() : original;
    }
