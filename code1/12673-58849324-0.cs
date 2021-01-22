    public static string FilterWhiteSpaces(string input)
    {
        if (input == null)
            return string.Empty;
        var stringBuilder = new StringBuilder(input.Length);
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (i == 0 || !char.IsWhiteSpace(c) || (char.IsWhiteSpace(c) && 
                !char.IsWhiteSpace(strValue[i - 1])))
                stringBuilder.Append(c);
        }
        return stringBuilder.ToString();
    }
