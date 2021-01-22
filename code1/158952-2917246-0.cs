    public bool IsNumeric(string input)
    {
       int result;
       return Int32.TryParse(input,out result);
    }
