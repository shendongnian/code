    public static bool CompareWildcards(this string WildString, string Mask, bool IgnoreCase)
    {
        int i = 0;
        if (String.IsNullOrEmpty(Mask))
            return false;
        if (Mask == "*")
            return true;
        while (i != Mask.Length)
            {
            if (CompareWildcard(WildString, Mask.Substring(i), IgnoreCase))
                return true;
            while (i != Mask.Length && Mask[i] != ';')
                i += 1;
            if (i != Mask.Length && Mask[i] == ';')
                {
                i += 1;
                while (i != Mask.Length && Mask[i] == ' ')
                    i += 1;
                }
            }
        return false;
    }
    public static bool CompareWildcard(this string WildString, string Mask, bool IgnoreCase)
    {
        int i = 0, k = 0;
        while (k != WildString.Length)
            {
            if (i > Mask.Length - 1)
                return false;
                
            switch (Mask[i])
                {
                case '*':
                    if ((i + 1) == Mask.Length)
                        return true;
                    while (k != WildString.Length)
                        {
                        if (CompareWildcard(WildString.Substring(k + 1), Mask.Substring(i + 1), IgnoreCase))
                            return true;
                        k += 1;
                        }
                    return false;
                case '?':
                    break;
                default:
                    if (IgnoreCase == false && WildString[k] != Mask[i])
                        return false;
                    if (IgnoreCase && Char.ToLower(WildString[k]) != Char.ToLower(Mask[i]))
                        return false;
                    break;
                }
            i += 1;
            k += 1;
            }
        if (k == WildString.Length)
            {
            if (i == Mask.Length || Mask[i] == ';' || Mask[i] == '*')
                return true;
            }
        return false;
    }
