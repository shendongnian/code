      public static bool PublicInstancePropertiesEqual<T>(T self, T to, params string[] ignore) where T : class 
      {
         if (self != null && to != null)
         {
            Type type = typeof(T);
            List<string> ignoreList = new List<string>(ignore);
            foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
               if (!ignoreList.Contains(pi.Name))
               {
                  object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                  object toValue = type.GetProperty(pi.Name).GetValue(to, null);
                  if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                  {
                     return false;
                  }
               }
            }
            return true;
         }
         return self == to;
      }
