    public static bool Or(this IEnumerable<bool> bList)
    {
        return bList.Contains(true);
    }
    
    public static bool And(this IEnumerable<bool> bList)
    {
        return !bList.Contains(false);
    }
