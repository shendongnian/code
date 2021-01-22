     public static string Test(IEnumerable<T> items, string separator)
        {
          
            var builder = new StringBuilder();
            bool appendSeperator = false;
            
            foreach(var item in items)
            {
          
            if(appendSeperator){
              builder.Append(separator)
            }
             
            builder.Append(item.ToString());
        
              appendSeperator = true;
          }
        
           return builder.ToString();
        }
