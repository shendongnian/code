    public static string RemoveInvalidXmlChars(string input)
    {
        return new string(input.Where(value =>
            (value >= 0x0020 && value <= 0xD7FF) ||
            (value >= 0xE000 && value <= 0xFFFD) ||
            value == 0x0009 ||
            value == 0x000A ||
            value == 0x000D).ToArray());
    }
