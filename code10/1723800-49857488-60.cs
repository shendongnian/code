    // basically that max value for a float
    public static List<string> GenerateInput38(int scale)
    {
    
       var result = Enumerable.Range(1, scale)
                               .Select(x => GetRadomFloatString(GetNumberFormatInfo(38)))
                               .ToList();
    
       result.Insert(0, (-0f).ToString("f", CultureInfo.InvariantCulture));
       result.Insert(0, "-0");
       result.Insert(0, float.NegativeInfinity.ToString("f", CultureInfo.InvariantCulture));
       result.Insert(0, float.PositiveInfinity.ToString("f", CultureInfo.InvariantCulture));
       return result;
    }
