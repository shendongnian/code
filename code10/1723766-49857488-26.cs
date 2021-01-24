    // Lets take this to the limit
    public static List<string> GenerateInput98(int scale)
    {
    
       var result = Enumerable.Range(1, scale)
                               .Select(x => GetRadomFloatString(GetNumberFormatInfo(98)))
                               .ToList();
    
       result.Insert(0, (-0f).ToString("f", CultureInfo.InvariantCulture));
       result.Insert(0, "-0");
       result.Insert(0, float.NegativeInfinity.ToString("f", CultureInfo.InvariantCulture));
       result.Insert(0, float.PositiveInfinity.ToString("f", CultureInfo.InvariantCulture));
       return result;
    }
