    char[] splitChars = new char[] { '_' };
    string[] strings = new[] {
        "file_1",
        "file_8",
        "file_11",
        "file_2"
    };
    
    Array.Sort(strings, delegate(string x, string y)
    {
        // split the strings into arrays on each '_' character
        string[] xValues = x.Split(splitChars);
        string[] yValues = y.Split(splitChars);
    
        // if the arrays are of different lengths, just 
        //make a regular string comparison on the full values
        if (xValues.Length != yValues.Length)
        {
            return x.CompareTo(y);
        }
    
        // So, the arrays are of equal length, compare each element
        for (int i = 0; i < xValues.Length; i++)
        {
            if (i == xValues.Length - 1)
            {
                // we are looking at the last element of the arrays
    
                // first, try to parse the values as ints
                int xInt = 0;
                int yInt = 0;
                if (int.TryParse(xValues[i], out xInt) 
                    && int.TryParse(yValues[i], out yInt))
                {
                    // if parsing the values as ints was successful 
                    // for both values, make a numeric comparison 
                    // and return the result
                    return xInt.CompareTo(yInt);
                }
            }
    
            if (string.Compare(xValues[i], yValues[i], 
                StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                break;
            }
        }
    
        return x.CompareTo(y);
    
    });
