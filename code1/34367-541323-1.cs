    public class StringPadder : ICustomFormatter
    {
      public string Format(string format, object arg,
           IFormatProvider formatProvider)
      {
         // do padding for string arguments
         // use default for others
      }
    }
    
    public class StringPadderFormatProvider : IFormatProvider
    {
      public object GetFormat(Type formatType)
      { 
         if (formatType == typeof(ICustomFormatter))
            return new StringPadder();
    
         return null;
      }
      public static readonly IFormatProvider Default =
         new StringPadderFormatProvider();
    }
