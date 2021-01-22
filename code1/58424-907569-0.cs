    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    // ...
    new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XElement("pages",
            Enumerable.Range(1, 4).Select(i =>
                new XElement("page",
                    new XAttribute("name", "Page Name " + i),
                    new XAttribute("url", "/page-" + i + "/")))))
      .WriteTo(XmlWriter.Create("output.xml"));
