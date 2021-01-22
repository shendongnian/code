    using (var writer = new XmlTextWriter("file.xml", Encoding.UTF8) { Formatting = Formatting.Indented })
    {
        const string Ns = "http://bladibla";
        const string Prefix = "abx";
    
        writer.WriteStartDocument();
    
        writer.WriteStartElement("root");
    
        // set root namespace
        writer.WriteAttributeString("xmlns", Prefix, null, Ns);
    
        writer.WriteStartElement(Prefix, "child", Ns);
        writer.WriteAttributeString("id", "A");
    
        writer.WriteStartElement("grandchild");
        writer.WriteAttributeString("id", "B");
    
        writer.WriteElementString(Prefix, "grandgrandchild", Ns, null);
    
        // grandchild
        writer.WriteEndElement();
        // child
        writer.WriteEndElement();
        // root
        writer.WriteEndElement();
    
        writer.WriteEndDocument();
    }
