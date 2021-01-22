     public static IEnumerable<string> GetNames<T>() where T:struct
     {
         var properties = typeof (T).GetProperties();
         foreach (var propertyInfo in properties)
         {
            yield return propertyInfo.Name;
         }
      }
