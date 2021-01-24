    // limits the out put to 10 characters
    // also because of that it has to check for trunced vales and
    // regenerates them
    public static List<string> GenerateInput10(int scale)
    {
       var result = new List<string>(scale);
       while (result.Count < scale)
       {
          var val = GetRadomFloatString(GetNumberFormatInfo(10));
          if (val != "0.0000000000")
             result.Add(val);
       }
    
       result.Insert(0, (-0f).ToString("f", CultureInfo.InvariantCulture));
       result.Insert(0, "-0");
          result.Insert(0, "0.00");
          result.Insert(0, float.NegativeInfinity.ToString("f", CultureInfo.InvariantCulture));
       result.Insert(0, float.PositiveInfinity.ToString("f", CultureInfo.InvariantCulture));
       return result;
    }
