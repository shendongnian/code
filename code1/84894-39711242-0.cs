    public static double StringToDouble(string toDouble)
    {
        string s = toDouble;
        if (!s.Contains(".") && !s.Contains(",")) s += ".0";
        string sep = System.Globalization.NumberFormatInfo.InvariantInfo.CurrencyDecimalSeparator; //Gets current separator
        if (sep != ".") s = s.Replace(sep, "."); //Replaces invariant separator with dot
    
        string left = s.Split('.')[0]; //Everything before the dot
        string right = s.Split('.')[1]; //Everything after the dot
    
        int iLeft = int.Parse(left); //Convert strings to ints
        int iRight = int.Parse(right);
    
        double d = iLeft + (iRight * Math.Pow(10, -(right.Length))); //Pure logic...
        return d;
    }
