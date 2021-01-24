    private static string AsciiCodesToString(int[] inputValues)
    {
        var builder = new StringBuilder();
        foreach (var value in inputValues)
        {
            builder.Append((char)value);
        }
        return builder.ToString();
    }
