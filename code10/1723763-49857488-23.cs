    // numberDecimalDigits specifies how long the output will be
    private static NumberFormatInfo GetNumberFormatInfo(int numberDecimalDigits)
    {
       return new NumberFormatInfo
                   {
                      NumberDecimalSeparator = ".",
                      NumberDecimalDigits = numberDecimalDigits
                   };
    }
    
    // generate a random float by create an int, and converting it to float in pointers
    
    private static unsafe string GetRadomFloatString(IFormatProvider formatInfo)
    {
       var val = Rand.Next(0, int.MaxValue);
       if (Rand.Next(0, 2) == 1)
          val *= -1;
       var f = *(float*)&val;
       return f.ToString("f", formatInfo);
    }
