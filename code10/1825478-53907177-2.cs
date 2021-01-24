    public static String GetAsCsvField(String input)
    {
        if (String.IsNullOrEmpty(input))
            return "\"\""
        return "\"" + input.Replace("\"", "\"\"") + "\""
    }
