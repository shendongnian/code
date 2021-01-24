    public decimal UniversalConvertDecimal(string str)
    {
        char currentDecimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        str = str.Replace('.', currentDecimalSeparator);
        str = str.Replace(',', currentDecimalSeparator);
        StringBuilder builder = new StringBuilder(str.Length);
        foreach(var ch in str)
        {
           if(Char.IsDigit(ch) || ch == currentDecimalSeparator)
             builder.Add(ch);             
        }
        string s = builder.ToString();
        return Convert.ToDecimal(s);
        
    }
