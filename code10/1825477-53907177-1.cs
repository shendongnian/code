    public static String GetAsCsvField(String input)
    {
        if (String.IsNullOrEmpty(input))
            return "\"\""
        input = input.Replace("\"", "\"\"");
        return "\"" + input + "\""
    }
