    class Program
    {
        static void Main(string[] args)
        {
            using (var xml = XmlWriter.Create(Console.Out, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
            {
                xml.WriteDocType("html", "-//W3C//DTD XHTML 1.0 Transitional//EN", "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", null);
                xml.WriteStartElement("html", "http://www.w3.org/1999/xhtml");
                xml.WriteAttributeString("xml", "lang", "", "en");
                xml.WriteEndElement();
            }
        }
    }
