    using System.IO;
    using System.Xml;
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    Stream stream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Encoding = Encoding.GetEncoding("ISO-8859-9");
    XmlWriter writer = XmlWriter.Create(stream, settings);
    doc.Save(writer);
