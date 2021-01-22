    private static StringBuilder BuildCommandLine(string executableFileName, string arguments)
    {
        StringBuilder builder = new StringBuilder();
        string str = executableFileName.Trim();
        bool flag = str.StartsWith("\"", StringComparison.Ordinal) && str.EndsWith("\"", StringComparison.Ordinal);
        if (!flag)
        {
            builder.Append("\"");
        }
        builder.Append(str);
        if (!flag)
        {
            builder.Append("\"");
        }
        if (!string.IsNullOrEmpty(arguments))
        {
            builder.Append(" ");
            builder.Append(arguments);
        }
        return builder;
    }
