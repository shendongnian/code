    public static string FixUp2(string s)
    {
        string result = "";     
        while (s.Length > 30)
        {    
            if (Char.IsWhiteSpace(s[29]) || Char.IsWhiteSpace(s[30]) ||
                s[29] == '-' || s[30] == '-')
            {
                result += s.Substring(0, 30)+"<br />";
            }
            else
            {
                result += s.Substring(0, 30)+"-<br />";
            }
            s = s.Substring(30);
        }
        result += s;
        return result;
    }
