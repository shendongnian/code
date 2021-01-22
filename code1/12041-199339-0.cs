    public bool isValidXml(string xml)
    {
        System.Xml.XmlDocument xDoc = null;
        bool valid = false;
        try
        {
            xDoc = new System.Xml.XmlDocument();
            xDoc.loadXml(xmlString);
            valid = true;
        }
        catch
        {
            // trap for errors
        }
        return valid;
    }
