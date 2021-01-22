    static string[] MultiStringToArray(
        char[] multistring
        )
    {
        List<string> stringList = new List<string>();
        int i = 0;
        while (i < multistring.Length)
        {
            int j = i;
            if (multistring[j++] == '\0') break;
            while (j < multistring.Length)
            {
                if (multistring[j++] == '\0')
                {
                    stringList.Add(new string(multistring, i, j - i - 1));
                    i = j;
                    break;
                }
            }
        }
        return stringList.ToArray();
    }
