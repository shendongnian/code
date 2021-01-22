    public enum ParseFailBehavior
    {
       ReturnNull,
       ReturnDefault,
       ThrowException
    }
    
    public static T? ParseNullableEnum<T>(this string theValue, ParseFailBehavior desiredBehavior = ParseFailBehavior.ReturnNull) where T:struct
    {
       T output;
       T? result = Enum.TryParse<T>(theValue, out output) 
          ? (T?)output
          : desiredBehavior == ParseFailBehavior.ReturnDefault
             ? (T?)default(T)
             : null;
    
       if(result == null && desiredBehavior == ParseFailBehavior.ThrowException)
          throw new ArgumentException("Parse Failed for value {0} of enum type {1}".
             FormatWith(theValue, typeof(T).Name));       
    }
