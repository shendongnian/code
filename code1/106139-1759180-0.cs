    using System;
    using System.ComponentModel;
    
    public static class Parser {
    
         public static T Parse<T>(this string value) {
            // Get default value for type so if string
            // is empty then we can return default value.
            T result = default(T);
    
            if (!string.IsNullOrEmpty(value)) {
              // we are not going to handle exception here
              // if you need SafeParse then you should create
              // another method specially for that.
              TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
              result = (T)tc.ConvertFrom(value);
            }
    
            return result;
        }
    }
