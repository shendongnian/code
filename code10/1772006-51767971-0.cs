    using (var sr = new StreamReader(@"yourXmlFilePath"))
    {
        var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
    
        using (var xmlReader = XmlReader.Create(sr, settings))
        {
            if (!xmlReader.Read()) throw new Exception("No line");
    
            var result = xmlReader.GetAttribute("encoding"); //returns utf-8
       
        }
    }
