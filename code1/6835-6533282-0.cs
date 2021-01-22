    public static string IsValidGuid(string str)
    {
        Guid guid;
        return Guid.TryParse(str, out guid);
    }
