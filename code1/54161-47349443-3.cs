    public static string NormalizeNewLine(this string val)
    {
        if (string.IsNullOrWhiteSpace(val))
            return val;
        const int page = 6;
        int a = page;
        int j = 0;
        int len = val.Length;
        char[] res = new char[len];
        for (int i = 0; i < len; i++)
        {
            char ch = val[i];
            if (ch == '\r')
            {
                int ni = i + 1;
                if (ni < len && val[ni] == '\n')
                {
                    res[j++] = '\r';
                    res[j++] = '\n';
                    i++;
                }
                else
                {
                    if (a == page) //ensure capacity
                    {
                        char[] nres = new char[res.Length + page];
                        Array.Copy(res, 0, nres, 0, res.Length);
                        res = nres;
                        a = 0;
                    }
                    res[j++] = '\r';
                    res[j++] = '\n';
                    a++;
                }
            }
            else if (ch == '\n')
            {
                int ni = i + 1;
                if (ni < len && val[ni] == '\r')
                {
                    res[j++] = '\r';
                    res[j++] = '\n';
                    i++;
                }
                else
                {
                    if (a == page) //ensure capacity
                    {
                        char[] nres = new char[res.Length + page];
                        Array.Copy(res, 0, nres, 0, res.Length);
                        res = nres;
                        a = 0;
                    }
                    res[j++] = '\r';
                    res[j++] = '\n';
                    a++;
                }
            }
            else
            {
                res[j++] = ch;
            }
        }
        return new string(res, 0, j);
    }
