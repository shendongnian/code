    protected string GetDocumentID(Lists.Lists ls, string ListGUID, string FileName)
    {
    	string strDocumentID = "-1";
    
    	string strViewGUID = "";
    	string strRowLimit = "50000";
    
    	XmlDocument xmlDoc = new XmlDocument();
    	XmlNode query = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
    	XmlNode viewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
    	XmlNode queryOptions = xmlDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
    
    	query.InnerXml = "";
    	viewFields.InnerXml = "";
    	queryOptions.InnerXml = "<IncludeAttachmentUrls>TRUE</IncludeAttachmentUrls>";
    
    	System.Xml.XmlNode nodeListItems = ls.GetListItems(ListGUID, strViewGUID, query, viewFields, strRowLimit, queryOptions, null);
    
    	XmlDocument doc = new XmlDocument();
    	doc.LoadXml(nodeListItems.InnerXml);
    	XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
    	nsmgr.AddNamespace("z", "#RowsetSchema");
    	nsmgr.AddNamespace("rs", "urn:schemas-microsoft-com:rowset");
    
    	foreach (XmlNode node in doc.SelectNodes("/rs:data/z:row", nsmgr))
    	{
    		if (node.Attributes["ows_LinkFilename"].Value == FileName)
    		{
    			strDocumentID = node.Attributes["ows_ID"].Value;
    			break;
    		}
    	}
    
    	return strDocumentID;
    }
