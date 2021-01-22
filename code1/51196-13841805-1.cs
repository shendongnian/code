    Enum HowNice {
      ReallyNice  = 0,
      SortOfNice  = 1,
      NotNice     = 2
    }
    internal static class HowNiceIsThis
    {
     const String[] strings = { "Really Nice", "Kinda Nice", "Not Nice At All" }
    
     public static String DecodeToString(this HowNice howNice)
     {
       return strings[(int)howNice];
     }
    }
