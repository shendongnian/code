    public static string Truncate( this string value, int maxLength )
        {
            if (string.IsNullOrEmpty(value)) { return value; }
    
            return new string(value.Take(maxLength).ToArray());// use LINQ and be happy
        }
