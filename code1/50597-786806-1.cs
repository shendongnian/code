    public static bool IsNothing( this string source )
    {
        if (source == null || source.Length == 0)
        {
            return true;
        }
        else if (source.Trim().Length == 0)
        {
            return true;
        }
        return false;
    }
