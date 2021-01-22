    public static bool EqualIfNotEmpty( this string source, string text )
    {
        if (string.IsNullOrEmpty(text))
        {
           return true; // select all elements
        }
        return string.Equals( source, text ); // select only matching
    }
