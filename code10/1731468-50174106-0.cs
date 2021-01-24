    XmlTextWriter writer = new XmlTextWriter("D:\\" + row["id"] + ".xml", System.Text.Encoding.UTF8);
    writer.WriteStartDocument(true);
    writer.Formatting = Formatting.Indented;
    writer.Indentation = 2;
    writer.WriteStartElement("Table");
    createNode("1", "Product 1", "1000", writer);
    writer.WriteEndElement();
    writer.WriteEndDocument();
    writer.Close();
