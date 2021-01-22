    public static string HtmlReplace(string value, string[] words,
        Func<string, string> htmlWrapper)
    {
        var sb = new StringBuilder(value.Length);
        int index = -1;
        int lastEndIndex = 0;
        foreach (var word in words)
        {
            while ((index = value.IndexOf(word, index + 1,
                StringComparison.InvariantCultureIgnoreCase)) != -1)
            {
                sb.Append(value.Substring(lastEndIndex, index - lastEndIndex));
                sb.Append(htmlWrapper(value.Substring(index, word.Length)));
                lastEndIndex = index + word.Length;
            }
        }
        sb.Append(value.Substring(lastEndIndex, value.Length - lastEndIndex));
        return sb.ToString();
    }
