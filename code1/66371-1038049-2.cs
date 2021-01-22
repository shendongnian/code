    public static string TrimNewLines(string text)
    {
        while (text.EndsWith(Environment.NewLine))
        {
            text = text.Substring(0, original.Length - Environment.NewLine.Length);
        }
        return text;
    }
