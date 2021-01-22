    public static IEnumerable<string> SplitString(string str)
    {
        int StartIndex = 0;
        bool IsQuoted = false;
        for (int I = 0; I < str.Length; I++)
        {
            if (str[I] == '"')
                IsQuoted = !IsQuoted;
            if ((str[I] == ';') && !IsQuoted)
            {
                yield return str.Substring(StartIndex, I - StartIndex);        
                StartIndex = I + 1;
            }
        }
        if (StartIndex < str.Length)
            yield return str.Substring(StartIndex);
    }
