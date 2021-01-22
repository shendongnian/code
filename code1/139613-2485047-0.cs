    public static List<string> Split(string searchStr, string[] separators)
    {
        List<string> result = new List<string>();
        int length = searchStr.Length;
        int lastMatchEnd = 0;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < separators.Length; j++)
            {
                string str = separators[j];
                int sepLen = str.Length;
                if (((searchStr[i] == str[0]) && (sepLen <= (length - i))) && ((sepLen == 1) || (String.CompareOrdinal(searchStr, i, str, 0, sepLen) == 0)))
                {
                    result.Add(searchStr.Substring(lastMatchEnd, i - lastMatchEnd));
                    result.Add(searchStr.Substring(i, sepLen));
                    i += sepLen - 1;
                    lastMatchEnd = i + 1;
                    break;
                }
            }
        }
        if (lastMatchEnd != length)
            result.Add(searchStr.Substring(lastMatchEnd));
        return result;
    }
