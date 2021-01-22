    public static string RemoveInvalidXmlChars(input string)
    {
        var isValid = new Predicate<char>(value =>
            (value >= 0x0020 && value <= 0xD7FF) ||
            (value >= 0xE000 && value <= 0xFFFD) ||
            value == 0x0009 ||
            value == 0x000A ||
            value == 0x000D);
        return new string(Array.FindAll(input.ToCharArray(), isValid));
    }
