    try 
    {
    //XmlDataDocument sourceXML = new XmlDataDocument();
    string xmlFile = Server.MapPath(”DVDlist.xml”);
    //create a XML file is not exist
    System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(xmlFile, null);
    //starts a new document
    writer.WriteStartDocument();
    //write comments
    writer.WriteComment(”Commentss: XmlWriter Test Program”);
    writer.Formatting = Formatting.Indented;
    writer.WriteStartElement(”DVDlist”);
    writer.WriteStartElement(”DVD”);
    writer.WriteAttributeString(”ID”, “1″);
    //write some simple elements
    writer.WriteElementString(”Title”, “Tere Naam”);
    writer.WriteStartElement(”Starring”);
    writer.WriteElementString(”Actor”, “Salman Khan”);
    writer.WriteEndElement();
    writer.WriteEndElement();
    writer.WriteEndElement();
    writer.Close();
    }
    catch (Exception e1) 
    {
      Page.Response.Write(e1); 
    }
    }
