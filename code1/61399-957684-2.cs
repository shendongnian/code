    public static int GetHashCode(params object[] values)
    {
        int hash = 17;
        foreach (object value in values)
        {
            hash = hash * 23 + value.GetNullSafeHashCode();
        }
        return hash;
    }
