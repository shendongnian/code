    public static string ReplaceNot(
        this string original, char[] pattern, char replacement)
    {
        char[] buffer = new char[original.Length];
        for (int i = 0; i < buffer.Length; i++)
        {
            bool replace = true;
            for (int j = 0; j < pattern.Length; j++)
            {
                if (original[i] == pattern[j])
                {
                    replace = false;
                    break;
                }
            }
            buffer[i] = replace ? replacement : original[i];
        }
        return new string(buffer);
    }
