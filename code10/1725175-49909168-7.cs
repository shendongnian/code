    StreamReader reader = new StreamReader(sourcepath);
    string xml = reader.ReadToEnd();
    reader.Close();
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    XmlNodeList list = doc.GetElementsByTagName("*");
    foreach (XmlNode nd in list)
    {
    	switch (nd.Name)
    	{
    		case "ContactID":
    			var ContactIdent = nd.InnerText;
    			break;
    		case "ContactName":
    			var ContactName = nd.InnerText;
    			break;
    	}
    }
