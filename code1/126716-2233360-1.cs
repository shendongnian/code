    internal static bool IsDangerousString(string s, out int matchIndex)
    {
        matchIndex = 0;
        int startIndex = 0;
        while (true)
        {
            int index = s.IndexOfAny(startingChars, startIndex);
            if (index < 0)
            {
                return false;
            }
            if (index == (s.Length - 1))
            {
                return false;
            }
            matchIndex = index;
            switch (s[index])
            {
                case 'E':
                case 'e':
                    if (IsDangerousExpressionString(s, index))
                    {
                        return true;
                    }
                    break;
    
                case 'O':
                case 'o':
                    if (!IsDangerousOnString(s, index))
                    {
                        break;
                    }
                    return true;
    
                case '&':
                    if (s[index + 1] != '#')
                    {
                        break;
                    }
                    return true;
    
                case '<':
                    if (!IsAtoZ(s[index + 1]) && (s[index + 1] != '!'))
                    {
                        break;
                    }
                    return true;
    
                case 'S':
                case 's':
                    if (!IsDangerousScriptString(s, index))
                    {
                        break;
                    }
                    return true;
            }
            startIndex = index + 1;
        }
    }
