    public static bool IsNullOrEmpty(string value)
    {
        if (value != null)
        {
            return (value.Trim().Length == 0);
        }
        return true;
    }
