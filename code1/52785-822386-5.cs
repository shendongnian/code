    public static string ProcessBackspaces(string source)
    {
        char[] buffer = new char[source.Length];
        int idx = 0;
        foreach (char c in source)
        {
            if (c != '\b')
            {
                buffer[idx] = c;
                idx++;
            }
            else if (idx > 0)
            {
                idx--;
            }
        }
        return new string(buffer, 0, idx);
    }
