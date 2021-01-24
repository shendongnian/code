    public static bool Or(List<bool> bList)
    {
        return bList.Contains(true);
    }
    
    public static bool And(List<bool> bList)
    {
        return !bList.Contains(false);
    }
