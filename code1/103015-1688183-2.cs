    public static bool ContainsIfNotEmpty( this string source, string text )
    {
        if (string.IsNullOrEmpty(text))
        {
           return true; // select all elements
        }
        if (string.IsNullOrEmpty(source))
        {
           return false; // select no elements
        }
        return source.Contains(text); // select only matching
    }
