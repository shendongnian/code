      public static T GetPropertyValue<T>(string propertyIdCode)
      {
         if (propertyIdCode == "firstName")
            return (T)Convert.ChangeType("Jim", typeof(T));
         if (propertyIdCode == "age")
            return (T)Convert.ChangeType(22, typeof(T));
         return default(T);
      }
