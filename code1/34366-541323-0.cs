    public class StringPadder : ICustomFormatProvider
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
      public ICustomFormatProvider GetFormat(Type type)
      { 
         if (formatType == typeof(ICustomFormatProvider))
            return new StringPadder();
    
         return null;
      }
      public static readonly IFormatProvider Default =
         new StringPadderFormatProvider();
    }
