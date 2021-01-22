    System.IO.StringWriter sw = new System.IO.StringWriter();
    XmlTextWriter writer = new XmlTextWriter(sw, Encoding.UTF8);
    writer.WriteProcessingInstruction("xml", "version=\"1.0\"");
    writer.WriteStartElement("Orders");
    //...start loop...
    writer.WriteStartElement("Order");
    writer.WriteAttributeString("OrderNumber", "12345");
    writer.WriteElementString("ItemNumber", "0123993587");
    writer.WriteElementString("QTY", "10");
    writer.WriteElementString("WareHouse", "PA019");
    writer.WriteEndElement();
    //...loop...
    writer.WriteEndElement();
