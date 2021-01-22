    WriteXml(XmlWriter writer, Transform sender)
    {
        string elementName = sender.GetType.Name;
        writer.WriteStartElement(elementName);   
        ............................
        ............................
        //and for each property inside a foreach
        writer.WriteStartElement(GeDotElement(elementName, propertyName))
    }
    private string GetExtension(string elementName, string propertyName)
    {
        return string.Format("{0}.{1}", elementName, propertyName);
    }
