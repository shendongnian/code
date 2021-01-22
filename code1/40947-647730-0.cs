    public static bool IsNullOrEmpty(string value)
    {
        value = value.Trim(); // sic!
        if (value != null)
        {
            return (value.Length == 0);
        }
        return true;
    }
