    List<XElement> ele = reportHost.hostProperties.ToList(); 
    foreach (var tag in ele)
    {
        if (tag.Attribute("name").Value == "device" )
        {
          Console.WriteLine($"device: {tag.Value}");
        }
        
        if (tag.Attribute("name").Value == "fqn" )
        {
          Console.WriteLine($"fqn: {tag.Value}");
        }
    }
