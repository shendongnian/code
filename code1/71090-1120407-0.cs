    public static string RemoveSpecialCharacters(string str)
    {
        char[] buffer = new char[str.Length];
        int idx = 0;
        foreach (char c in str)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z')
                || (c >= 'a' && c <= 'z') || (c == '.') || (c == '_'))
            {
                buffer[idx] = c;
                idx++;
            }
        }
        return new string(buffer, 0, idx);
    }
