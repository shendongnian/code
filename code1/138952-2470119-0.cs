    using System.Xml.Linq;
    using System.Xml.XPath;
    var doc = XElement.Load("test.xml");
    doc.XPathSelectElement("//customer").Remove();
    doc.Save("test.xml");
