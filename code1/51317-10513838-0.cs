     public static void AddStyleLink(string href)
     {
          Page page = (Page)HttpContext.Current.CurrentHandler;        
    
          var existing = 
              (from c 
              in page.Header.Controls.OfType<HtmlGenericControl>() 
              where c.Attributes["href"] == href
              select c).FirstOrDefault();
    
          if (existing == null)
          {
              HtmlGenericControl link = new HtmlGenericControl("link");
              link.Attributes.Add("rel", "stylesheet");
              link.Attributes.Add("href", href);
              page.Header.Controls.Add(link);
          }            
     }
