    public static string Test(IEnumerable<T> items, string separator)
    {
      
                var builder = new StringBuilder();
        
                bool firstItem = true;
      foreach(var item in items)
    {
      
       builder.Append(
           ((firstItem) ? String.Empty : separator)
         + item.ToString()
    
    );
    
          firstItem = false;
      }
    
                return builder.ToString();
        }
    
    }
