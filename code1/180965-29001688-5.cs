    // string Join(this IEnumerable<string> strings, string delimiter)
    // was not introduced until 4.0. So provide our own.
    #if ! NETFX_40 && NETFX_35
    public static string Join( string delimiter, IEnumerable<string> strings)
    {
        return string.Join(delimiter, strings.ToArray());
    }
    #endif
