    public static class SafeConverter
    {
       public static T SafeConvert<T>(object input, T defaultValue)
       {
           if (input == null)
              return defaultValue; //default(T);
           T result;
           try
           {
               result = (T)Convert.ChangeType(input.ToString(), typeof(T));
           }
           catch
           {
              result = defaultValue; //default(T);
           }
           return result;
       }
    } 
