    string xml = @"<root>
                    <startingPoint coordinates=""1,1"" player=""1"" />
                    <startingPoint coordinates=""2,2"" player=""2"" />
                   </root>";
    
    XDocument document = XDocument.Parse(xml);
    
    var query = (from startingPoint in document.Descendants("startingPoint")
                 select new
                 {
                     Key = (int)startingPoint.Attribute("player"),
                     Value = (string)startingPoint.Attribute("coordinates")
                 }).ToDictionary(pair => pair.Key, pair => pair.Value);
    
    foreach (KeyValuePair<int, string> pair in query)
    {
        Console.WriteLine("{0}\t{1}", pair.Key, pair.Value);
    }
