    public static bool IsNumeric(string strNumber)
    {
       bool r = strNumber.All(char.IsDigit);
       return r;
    }
