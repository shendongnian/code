    public static string FirstCharacterToLower(string str)
    {
        if (String.IsNullOrEmpty(str) || Char.IsLower(str, 0))
            return str;
        return Char.ToLowerInvariant(str[0]) + str.Substring(1);
    }
