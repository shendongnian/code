    private bool m_LoadXML(out XmlElement xmlRoot, string strXMLScript)
    {
        bool blnResult = false;
        string strMsg;
        var xmlDoc = new XmlDocument();
        try
        {
            xmlDoc.Load(strXMLScript);
            xmlRoot = xmlDoc.DocumentElement;
            if (xmlRoot != null) blnResult = true;
            else
            {
                strMsg = "Invalid XML database definition file " + strXMLScript;
                MessageBox.Show(strMsg);
            }
        }
        catch (Exception)
        {
            strMsg = "Can not load XML database definition file " + strXMLScript;
            MessageBox.Show(strMsg);
            throw;
        }
        return blnResult;
    }
    private void TestLoadXml(string xmlFile)
    {
        XmlElement elem;
        var result = m_LoadXML(out elem, xmlFile);
    }
