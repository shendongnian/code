       public static string Transform(string expression) {
         if (string.IsNullOrEmpty(expression))
           return expression;
         StringBuilder sb = new StringBuilder(expression.Length);
         bool inQuotation = false;
         foreach (char c in expression) 
           if (c == ',' && !inQuotation)
             sb.Append('.');
           else {
             if (c == '\'')
               inQuotation = !inQuotation; 
             sb.Append(c);
           }  
         return sb.ToString(); 
       }
