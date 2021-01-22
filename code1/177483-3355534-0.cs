    public static bool IsBase64String(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return false;
        }
        try
        {
            Convert.FromBase64String(value);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
