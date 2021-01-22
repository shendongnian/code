    [Flags]
    enum Level:int
    {
        Red = 1,
        Green = 2,
        Blue = 4,
        Yellow = Red | Green,
        White = Red | Green | Blue
    }
    public class myControl : WebControl
    {
     public Level color;
     ...
    }
    
    public static class extension
    {
     public static bool Compare(this Level source, Level comparer)
     {
      return (source &  comparer) > 0; // will check RGB base color
      //return (source & comparer) == source; // will check for exact color
     }
    }
