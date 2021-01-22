     if (!string.IsNullOrEmpty(SearchString))
        {
         List<String> containValues = new List<String>();
         if (SearchString.Contains("*"))
            {
    
            String[] pieces = SearchString.Split("*");
                       
            foreach (String piece in pieces)
                    {
                    if (piece != "")
                       {
                       containValues.Add(piece);
                       }
                     }
               }
                  
           if (containValues.Count > 0)
              {
              foreach(String thisValue in containValues)
                 {
                 Items = Items.Where(s => s.Description.Contains(thisValue));
                 }
               }
               else
               {
               Items = Items.Where(s => s.Description.Contains(SearchString));
               }
           }
