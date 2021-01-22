    public static string AppendText(this string thisString, 
                                    string append, 
                                    bool removeNewLine = true)
    {
        if (removeNewLine)
        {
            if (append.Contains('\r'))
            {
                // String came Windows land
                append = append.Replace(Environment.NewLine, string.Empty);
            }
            else
            {
                // String came from UNIX land
                append = append.Replace("\n", string.Empty);
            }
        }
        return thisString + append;
    }
