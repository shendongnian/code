    using System.Xml.Linq;
    
    var doc = XDocument.Parse(xml); // or XDocument.Load()
    var elements = from e in doc.Descendants("answer")
                   where e.Attribute("status").Value == "attempt"
                   select e;
    // elements will be IEnumerable<XElement>
