    bool isAllLetters(string s)
    {
        foreach (char c in s)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }
