    private static string TitleCaseConvert(string title)
    {
        int wordStart = 0;
        
        char[] result = new char[title.Length];
        int ri = 0;
        for (int i = 0; i < title.Length; ++i)
        {
            if (title[i] == '_')
            {
                wordStart = i + 1;
            }
            else if (i == wordStart)
            {
                result[ri++] = Char.ToUpper(title[i]);
            }
            else
            {
                result[ri++] = Char.ToLower(title[i]);
            }
        }
        
        return new String(result, 0, ri);
    }
