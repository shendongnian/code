            StringBuilder output = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(output);
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
            writer.Close();
