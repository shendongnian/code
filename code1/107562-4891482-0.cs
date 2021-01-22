    public bool IsPalindrome(string stringToCheck)
    {
       char[] rev = stringToCheck.Reverse().ToArray();
       return (stringToCheck.Equals(new string(rev), StringComparison.OrdinalIgnoreCase));
    }
