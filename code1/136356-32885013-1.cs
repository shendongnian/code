    public void BindData()
    {                    
        StringWriter sw = new StringWriter();
        XmlTextWriter writer = new XmlTextWriter(sw);
        XmlDocument doc = new XmlDocument();
        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        writer.WriteStartElement("feed");
        writer.WriteAttributeString("xmlns", "http://www.w3.org/2005/Atom");
        writer.WriteString("\n");
        writer.WriteElementString("title", this.TTT + " - " + this.Title);
        writer.WriteString("\n");
        
        
        writer.WriteStartElement("link");
        writer.WriteAttributeString("href", this.Url );
        writer.WriteEndElement();
        writer.WriteElementString("id", "urn:uuid:" + Guid.NewGuid().ToString());            
        writer.WriteElementString("updated", DateTime.UtcNow.ToString("o"));
        foreach (var  item in this.lista)
        {
            writer.WriteStartElement("entry");
            writer.WriteElementString("title", item.Value.Title);
            writer.WriteStartElement("link");
            writer.WriteAttributeString("href", item.Key);
            writer.WriteEndElement();
            writer.WriteElementString("id", item.Key);
            string slikaImgUrl = item.Value.Imaga;
            if (string.IsNullOrEmpty(slikaImgUrl) == false)
            {
                writer.WriteStartElement("link");
                writer.WriteAttributeString("rel", "enclosure");
                writer.WriteAttributeString("type", "image/jpeg");
                writer.WriteAttributeString("href", slikaImgUrl);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("author");
            writer.WriteElementString("name", this.Title);
            writer.WriteEndElement();
            writer.WriteStartElement("summary");
            writer.WriteAttributeString("type", "text");
            writer.WriteCData(" ");
            writer.WriteEndElement();               
            writer.WriteElementString("updated", DateTime.UtcNow.ToString("o"));
            writer.WriteElementString("published", DateTime.UtcNow.ToString("o"));
            writer.WriteEndElement();
            writer.WriteString("\n");                
        }
        writer.WriteEndElement();
        string dataOut = sw.ToString();
        Response.Clear();
        Response.ContentType = "text/xml";
        Response.Write(dataOut);
        writer.Close();
        Response.End();
    }
