    public static string Transform(string str)
    {
        int lvl = 0;
        var sb = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];
            switch (ch)
            {
                case '<':
                    if (lvl == 0)
                    {
                        ch = '{';
                    }
                    lvl++;
                    break;
                case '>':
                    if (lvl == 0)
                    {
                        throw new Exception($"Malformed string at pos {i}");
                    }
                    else if (lvl == 1)
                    {
                        ch = '}';
                    }
                    lvl--;
                    break;
                case '+':
                    if (lvl == 1)
                    {
                        ch = '=';
                    }
                    break;
            }
            sb.Append(ch);
        }
        return sb.ToString();
    }
