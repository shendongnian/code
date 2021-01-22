    public static bool IsValidGuid(string str)
    {
        Guid guid;
        return Guid.TryParse(str, out guid);
    }
