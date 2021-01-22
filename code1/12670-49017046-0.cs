    public static string MergeSpaces(this string str)
    {
        if (str == null)
        {
            return null;
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder(str.Length);
            int i = 0;
            foreach (char c in str)
            {
                if (c != ' ' || i == 0 || str[i - 1] != ' ')
                    stringBuilder.Append(c);
                i++;
            }
            return stringBuilder.ToString();
        }
    }
