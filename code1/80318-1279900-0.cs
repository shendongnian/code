    public static string DontUseThisToCollapseSpaces(string text)
    {
        while (text.IndexOf("  ") != -1)
        {
            text = text.Replace("  ", " ");
        }
        return text;
    }
