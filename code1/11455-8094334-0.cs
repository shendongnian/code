    public static class Globber
    {
        public static bool Glob(this string value, string pattern)
        {
            int pos = 0;
            while (pattern.Length != pos)
            {
                switch (pattern[pos])
                {
                    case '?':
                        break;
                    case '*':
                        for (int i = value.Length; i >= pos; i--)
                        {
                            if (Glob(value.Substring(i), pattern.Substring(pos + 1)))
                            {
                                return true;
                            }
                        }
                        return false;
                    default:
                        if (value.Length == pos || char.ToUpper(pattern[pos]) != char.ToUpper(value[pos]))
                        {
                            return false;
                        }
                        break;
                }
                pos++;
            }
            return value.Length == pos;
        }
    }
