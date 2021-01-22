    static string ReverseString(string text)
    {
        string sub = "";
        int indexCount = text.Length - 1;
        for (int i = indexCount; i > -1; i--)
        {
            sub = sub + text.Substring(i, 1);
        }
        return sub;
    }
