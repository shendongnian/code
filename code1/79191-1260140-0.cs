       try
        {
        	System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        	doc.Load(Server.MapPath("XMLFile.xml"));
        }
        catch (System.Xml.XmlException xmlEx)
        {
        	if (xmlEx.Message.Contains("Root element is missing"))
        	{
        		// Xml file is empty
        	}
        }
