    public static bool MatchesWildcard(this string text, string pattern)
    {
        int it = 0;
        while (text.CharAt(it) != 0 &&
               pattern.CharAt(it) != '*')
        {
            if (pattern.CharAt(it) != text.CharAt(it) && pattern.CharAt(it) != '?')
                return false;
            it++;
        }
        int cp = 0;
        int mp = 0;
        int ip = it;
        while (text.CharAt(it) != 0)
        {
            if (pattern.CharAt(ip) == '*')
            {
                if (pattern.CharAt(++ip) == 0)
                    return true;
                mp = ip;
                cp = it + 1;
            }
            else if (pattern.CharAt(ip) == text.CharAt(it) || pattern.CharAt(ip) == '?')
            {
                ip++;
                it++;
            }
            else
            {
                ip = mp;
                it = cp++;
            }
        }
        while (pattern.CharAt(ip) == '*')
        {
            ip++;
        }
        return pattern.CharAt(ip) == 0;
    }
    
    public static char CharAt(this string s, int index)
    {
        if (index < s.Length)
            return s[index];
        return '\0';
    }
