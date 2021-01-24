    public static double ToDoubleOrDefault(this string value) {
      var doubleValue = default(double);
      // We don't have to create new instances (new CultureInfo()...)
      var danishCultureInfo = CultureInfo.GetCultureInfo("da-DK");
      var englishCultureInfo = CultureInfo.GetCultureInfo("en-US");
      if (double.TryParse(value, 
                          NumberStyles.AllowDecimalPoint, 
                          englishCultureInfo, 
                          out doubleValue)) 
        return doubleValue;
      else if (double.TryParse(value, 
                               NumberStyles.AllowDecimalPoint, 
                               danishCultureInfo, 
                               out doubleValue)) 
        return doubleValue;
      else if (double.TryParse(value, 
                               NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, 
                               englishCultureInfo, 
                               out doubleValue)) 
        return doubleValue;
      else if (double.TryParse(value, 
                               NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, 
                               danishCultureInfo, 
                               out doubleValue)) 
        return doubleValue;
      return doubleValue;
    }
