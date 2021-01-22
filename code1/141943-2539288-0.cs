    string xml = @"<ruleDefinition appId=""3"" customerId = ""acf""> 
        <node alias=""element1"" id=""1"" name=""department"">
            <node alias=""element2"" id=""101"" name=""mike"" /> 
            <node alias=""element2"" id=""102"" name=""ricky"" />
            <node alias=""element2"" id=""103"" name=""jim"" />
        </node>
        </ruleDefinition>";
    
    XDocument document = XDocument.Parse(xml);
    
    var query = from node in document.Descendants("node")
                where node.Attribute("alias").Value == "element1"
                select new
                {
                    Element1 = new
                               {
                                   Id = node.Attribute("id").Value,
                                   Name = node.Attribute("name").Value
                               },
    
                    Element2 = from n in node.Descendants("node")
                               where n.Attribute("alias").Value == "element2"
                               select new
                               {
                                   Id = n.Attribute("id").Value,
                                   Name = n.Attribute("name").Value
                               }
                };
    
    foreach (var item in query)
    {            
        Console.WriteLine("{0}\t{1}", item.Element1.Id, item.Element1.Name);
    
        foreach (var element2 in item.Element2)
            Console.WriteLine("\t{0}\t{1}", element2.Id, element2.Name);
    }
