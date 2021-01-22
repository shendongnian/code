    XDocument main = XDocument.Load("XMLFile1.xml");
    XDocument changes = XDocument.Load("XMLFile2.xml");
       
    var merge = from entry in main.Descendants("preset").Descendants("var")
                join change in changes.Descendants("preset").Descendants("var")
                on 
                   new {a=entry.Attribute("id").Value, b=entry.Attribute("opt").Value}
                equals 
                   new {a=change.Attribute("id").Value, b=change.Attribute("opt").Value}
                select new
                {
                   Element = entry,
                   newValue = change.Attribute("val").Value                       
                };
        
                merge.ToList().ForEach(i => i.Element.Attribute("val").Value = i.newValue);
        
                main.Save("XMLFile3.xml");
