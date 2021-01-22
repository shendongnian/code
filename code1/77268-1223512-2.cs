    public static bool validateIsMoreThanOneWord(string input, int numberWords)
    {
        if (string.IsNullOrEmpty(input)) return false;
    
        return ( input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Length >= numberWords);    
    }
