    List<XElement> hostProperties = reportHost.hostProperties.ToList(); 
    
    foreach (var hp in hostProperties)
    {
        // all of the <tag> elements
        var tags = hp.Element("HostProperties").Elements("tag");
        
        foreach (var tag in tags)
        {
          // get the attribute with the name of "name"
          var tagName = tag.Attribute("name");
          
          // check to make sure a <tag> element exists with a "name" attribute
          if (tagName != null)
          {
            if (tagName.Value == "device")
            {
              Console.WriteLine($"device: {tag.Value}");
            }
            else if (tagName.Value == "fqn")
            {
              Console.WriteLine($"fqn: {tag.Value}");
            }
          }
        
        }
    }
