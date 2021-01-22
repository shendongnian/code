    public static bool IsNothing( this string source )
    {
        if (source == null)
        {
            return true;
        }
        else if (string.IsNullOrEmpty( source.Trim() ))
        {
            return true;
        }
        return false;
    }
