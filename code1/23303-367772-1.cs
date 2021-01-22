    using System.Xml.Linq;
    
    XDocument xmlFile = XDocument.Load("books.xml"); 
    
    var query = from c in xmlFile.Elements("catalog").Elements("book")    
                select c; 
    
    foreach (XElement book in query) 
    {
       book.Attribute("attr1").Value = "MyNewValue";
    }
    
    xmlFile.Save("books.xml");
