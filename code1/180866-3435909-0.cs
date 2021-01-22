    private String GetNodeValue(ref XmlDocument oXMLDoc, String sPath)
    {
        String sValue = "";
        XmlNode oNode = oXMLDoc.SelectSingleNode(sPath);
        if (oNode != null)
        {
            sValue = oNode.InnerText.Trim();
        }
        return sValue;
    }
    
    private void SetNodeValue(ref XmlDocument oXMLDoc, String sPath, String sValue)
    {
        XmlNode oNode = oXMLDoc.SelectSingleNode(sPath);
        if (oNode != null)
        {
            oNode.InnerText = sValue;
        }
    }
