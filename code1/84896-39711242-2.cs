    public static double StringToDouble(string toDouble)
    {
        toDouble = toDouble.Replace(",", "."); //Replace every comma with dot
        
        //Count dots in toDouble, and if there is more than one dot, throw an exception.
        //Value such as "123.123.123" can't be converted to double
        int dotCount = 0;
        foreach (char c in toDouble) if (c == '.') dotCount++; //Increments dotCount for each dot in toDouble
        if (dotCount > 1) throw new Exception(); //If in toDouble is more than one dot, it means that toCount is not a double
        
        string left = toDouble.Split('.')[0]; //Everything before the dot
        string right = toDouble.Split('.')[1]; //Everything after the dot
        
        int iLeft = int.Parse(left); //Convert strings to ints
        int iRight = int.Parse(right);
        
        //We must use Math.Pow() instead of ^
        double d = iLeft + (iRight * Math.Pow(10, -(right.Length)));
        return d;
    }
