    How about this code block ?   
         
          public static List<string> ToList(this string str)
          {
            return str.Split(',').Where(vstr => 
              !string.IsNullOrWhiteSpace(vstr)).Distinct().ToList();
          }
