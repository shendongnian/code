    public string ParsingAll(int i, string cssSelector, string attr) 
    {
      try
      {
        string str1 = "def";
        switch (i)
        {
          case 0: 
            var items = document.QuerySelectorAll(cssSelector); 
    
            str1 = items[0].TextContent.Trim();
    
            break;
        }
            return str1;
      }
      catch (Exception ex)
      {
        string s = ex.Message;    
        return null;
      }
    
      return null;
    }
