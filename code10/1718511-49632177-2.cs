    public static bool Or(IList<bool> bList)
    {
        return bList.Contains(true);
    }
    
    public static bool And(IList<bool> bList)
    {
        return !bList.Contains(false);
    }
