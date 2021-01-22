    string Sanitize(string s)
    {
        if (s == null)
        {
            return null;
        }
        char[] buffer = new char[s.Length];
        int pos = 0;
        bool inSpace = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ' || s[i] == '\t' || s[i] == '\r' || s[i] == '\n')
            {
                if (!inSpace)
                {
                    buffer[pos] = ' ';
                    pos++;
                }
                inSpace = true;
            }
            else
            {
                buffer[pos] = s[i];
                pos++;
                inSpace = false;
            }
        }
        return new string(buffer, 0, pos).Trim();
    }
