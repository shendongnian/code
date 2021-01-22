    using (XmlWriter writer = XmlWriter.Create("filename.xml"))
    {
        writer.WriteStartElement("User");
        writer.WriteElementString("Username", inputUserName);
        writer.WriteElementString("Email", inputEmail);
        writer.WriteEndElement();
    }
