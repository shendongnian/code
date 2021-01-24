    List<XElement> ele = reportHost.hostProperties.ToList(); 
    var device = ele.First(a =>a.Attribute("name").Value == "device" );
           
    var fqn = ele.First(a =>a.Attribute("name").Value == "fqn" );
    
    Console.WriteLine($"device: {device.Value}");
    Console.WriteLine($"fqn: {fqn.Value}");
