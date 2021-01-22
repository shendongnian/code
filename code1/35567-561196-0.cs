    public static string Format(char splitChar, string format,
                                params object[] args)
    {
        string splitStr = splitChar.ToString();
        StringBuilder str = new StringBuilder(format + args.Length * 2);
        for (int i = 0; i < str.Length; ++i)
        {
            if (str[i] == splitChar)
            {
                string index = "{" + i + "}";
                str.Replace(splitStr, index, i, 1);
                i += index.Length - 1;
            }
        }
        return String.Format(str.ToString(), args);
    }
