    XmlDocument doc = new XmlDocument();
    doc.AppendChild(doc.CreateXmlDeclaration("1.0", "us-ascii", ""));
    XmlElement elem = doc.CreateElement("ASCII");
    doc.AppendChild(elem);
    byte[] b = new byte[1];
    for (int i = 0; i < 128; i++)
    {
        b[0] = Convert.ToByte(i);
        XmlElement e = doc.CreateElement("ASCII_" + i.ToString().PadLeft(3,'0'));
        e.InnerText = System.Text.ASCIIEncoding.ASCII.GetString(b);
        elem.AppendChild(e);
    }
    Console.WriteLine(doc.OuterXml);
