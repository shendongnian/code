    public static IEnumerable<CultureInfo> GetAvailableCultures()
    {
      List<CultureInfo> result = new List<CultureInfo>();
      ResourceManager rm = new ResourceManager(typeof(Resources));
 
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
      foreach (CultureInfo culture in cultures)
      {
        try
        {
          if (culture.Equals(CultureInfo.InvariantCulture)) continue; //do not use "==", won't work
          ResourceSet rs = rm.GetResourceSet(culture, true, false);
          if (rs != null)
            result.Add(culture);
        }
        catch (CultureNotFoundException)
        {
          //NOP
        }
      }
      return result;
    }
