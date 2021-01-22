    public static string TrimNewLines(string text)
    {
        while (text.EndsWith(Environment.NewLine))
        {
            text = text.Substring(0, text.Length - Environment.NewLine.Length);
        }
        return text;
    }
