    public static string ToInitcap(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        char[] charArray = new char[str.Length];
        bool newWord = true;
        for (int i = 0; i < str.Length; ++i)
        {
            Char currentChar = str[i];
            if (Char.IsLetter(currentChar))
            {
                if (newWord)
                {
                    newWord = false;
                    currentChar = Char.ToUpper(currentChar);
                }
                else
                {
                    currentChar = Char.ToLower(currentChar);
                }
            }
            else if (Char.IsWhiteSpace(currentChar))
            {
                newWord = true;
            }
            charArray[i] = currentChar;
        }
        return new string(charArray);
    }
