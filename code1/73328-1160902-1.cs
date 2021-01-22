    string xml = "<myXML>";
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    using(StringWriter sw = new StringWriter())
    {
        doc.Save(sw);
        Console.Write(sw.GetStringBuilder().ToString());
    }
