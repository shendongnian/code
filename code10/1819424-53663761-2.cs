    var src = new Source();
    src.ID = "1";
    src.Name = "Test";
    src.Address = "<Country>MyCountry</Country><Prefecture>MyPrefecture</Prefecture><City>MyCity</City>";
    
    XDocument xdoc = new XDocument();
    xdoc = XDocument.Parse($"<Root>{src.Address}</Root>");
    
    Mapper.Initialize(cfg =>
                        cfg.CreateMap<Source, Destination>()
                        .ConstructUsing(x=>ConstructDestination(x))
                     );
    
