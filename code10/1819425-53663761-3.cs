    static Destination ConstructDestination(Source src)
    {
       XDocument xdoc = new XDocument();
       xdoc = XDocument.Parse($"<Root>{src.Address}</Root>");
    
       return new Destination
       {
         Country = xdoc.Root.Element(nameof(Destination.Country)).Value,
         City = xdoc.Root.Element(nameof(Destination.City)).Value,
         Prefecture = xdoc.Root.Element(nameof(Destination.Prefecture)).Value,
       };
    
     }
