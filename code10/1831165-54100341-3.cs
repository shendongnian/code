        List<XElement> hostProperties = reportHost.hostProperties.ToList(); 
        
        foreach (var hp in hostProperties)
        {
            var tags = hp.Element("HostProperties").Elements("tag");
            
            var device = tags.FirstOrDefault(a=> a.Attribute("name").Value == "device");
            if (device != null)
            {
              Console.WriteLine($"device: {device.Value}");
            }
            
            var fqn = tags.FirstOrDefault(a=> a.Attribute("name").Value == "fqn");
            
            if (fqn != null)
            {
              Console.WriteLine($"fqn: {tag.Value}");
            }
        }
