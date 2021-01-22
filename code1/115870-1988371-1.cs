    WriteXml(XmlWriter writer, Transform sender)
    {
        string elementName = sender.GetType.Name;
        writer.WriteStartElement(elementName);   
        ............................
        ............................
        //and for each property inside a foreach
        writer.WriteStartElement(GetDotElement(elementName, propertyName));
    }
    private string GetDotElement(string elementName, string propertyName)
    {
        return string.Format("{0}.{1}", elementName, propertyName);
    }
