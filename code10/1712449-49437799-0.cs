    static void Main(string[] args)
    {
        string correctWord = "Potato";
        string incorrectSwappedWord = "potaot";
        string incorrectOneLetter = "ptato";
        // Returns true
        bool swapped = SwappedLettersMatch(correctWord, incorrectSwappedWord);
        // Returns true
        bool oneLetter = OneLetterOffMatch(correctWord, incorrectOneLetter);
    }
    public static bool OneLetterOffMatch(string str, string input)
    {
        int ndx = 0;
        str = str.ToLower();
        input = input.ToLower();
        if (string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace(input))
        {
            return false;
        }
        while (ndx < str.Length)
        {
            string newStr = str.Remove(ndx, 1);
            if (input == newStr)
            {
                return true;
            }
            ndx++;
        }
        return false;
    }
    public static bool SwappedLettersMatch(string str, string input)
    {
        if (string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace(input))
        {
            return false;
        }
        if (str.Length != input.Length)
        {
            return false;
        }
        str = str.ToLower();
        input = input.ToLower();
        int ndx = 0;
        while (ndx < str.Length)
        {
            if (ndx == str.Length - 1)
            {
                return false;
            }
            string newStr = str[ndx + 1].ToString() + str[ndx];
            if (ndx > 0)
            {
                newStr = str.Substring(0, ndx) + newStr;
            }
            if (str.Length > ndx + 2)
            {
                newStr = newStr + str.Substring(ndx + 2);
            }
            if (newStr == input)
            {
                return true;
            }
            ndx++;
        }
        return false;
    }
