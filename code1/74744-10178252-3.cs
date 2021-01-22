    public static bool IsAllLetters(string s)
    {
        foreach (char c in s)
        {
            if (!Char.IsLetter(c))
                return false;
        }
        return true;
    }
