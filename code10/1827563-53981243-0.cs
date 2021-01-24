    private void referenceToXML(string path)
    {
        var xmlDoc = XDocument.Load(filePath);
        xmlDoc.Element("ItemCollection").Element("Items").Add(
            new XElement("Item", new XAttribute("name", question.text), SM.text));
        xmlDoc.Save(path);
    }
