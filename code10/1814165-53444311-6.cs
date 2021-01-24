    XDocument doc = XDocument.Parse(xml);
    
    Dictionary<string, object> dict = doc.Root.Elements()
       .GroupBy(x => x.Name.LocalName, y => new
       {
           Name = y.Element("NAME").Value,
           Location = y.Element("LOCATION").Value
       })
       .ToDictionary(x => x.Key, y => (object)y.ToList());
    
    string json = JsonConvert.SerializeObject(dict);
    
    Console.WriteLine(json);
