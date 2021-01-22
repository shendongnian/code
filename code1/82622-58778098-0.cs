    using System.Xml.Linq;
    void method()
    {
        byte[] bytes = GetXmlBytes();
        XDocument doc;
        using (var stream = new MemoryStream(docBytes))
        {
            doc = XDocument.Load(stream);
        }
     }
