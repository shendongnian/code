    public string GetMimeType(string ext)
    {
      // who would load the file on every method call?  That's just dumb
      var mimes = XElement.Load("MyMimeTypesLolKThx.xml");
      var result = from x in mimes.Elements() 
                   where Contains(x, ext) 
                   select x.Attribute("Type");
      return result.FirstOrDefault() ?? "application/octet-stream";
    }
    
    public bool Contains(XElement el, string ext)
    {
      return el.Attribute("Extensions").Value.Contains(ext);  
    }
