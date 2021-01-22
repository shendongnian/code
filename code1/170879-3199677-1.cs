     /// <summary>
     /// Creates a comma delimeted string of all the objects property values names.
     /// </summary>
     /// <param name="obj">object.</param>
     /// <returns>string.</returns>
     public static string ObjectToCsvData(object obj)
     {
         if (obj == null)
         {
             throw new ArgumentNullException("obj", "Value can not be null or Nothing!");
         }
      
         StringBuilder sb = new StringBuilder();
         Type t = obj.GetType();
         PropertyInfo[] pi = t.GetProperties();
      
         for (int index = 0; index < pi.Length; index++)
         {
             sb.Append(pi[index].GetValue(obj, null));
      
             if (index < pi.Length - 1)
             {
                sb.Append(",");
             }
         }
      
         return sb.ToString();
     }
