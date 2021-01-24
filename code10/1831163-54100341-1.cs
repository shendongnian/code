    List<XElement> ele = reportHost.hostProperties.ToList(); 
    var device = ele.Element("HostProperties")
                    .Elements("tag")
                    .First(a =>a.Attribute("name").Value == "device" );
           
    var fqn = ele.Element("HostProperties")
                 .Elements("tag")
                 .First(a =>a.Attribute("name").Value == "fqn" );
    
    Console.WriteLine($"device: {device.Value}");
    Console.WriteLine($"fqn: {fqn.Value}");
