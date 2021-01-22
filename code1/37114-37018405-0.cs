	static public class XmlDocumentExt
	{
		static public XmlNamespaceManager GetPopulatedNamespaceMgr(this System.Xml.XmlDocument xd)
		{
			XmlNamespaceManager nmsp = new XmlNamespaceManager(xd.NameTable);
			XPathNavigator nav = xd.DocumentElement.CreateNavigator();
			foreach (KeyValuePair<string,string> kvp in nav.GetNamespacesInScope(XmlNamespaceScope.All))
			{
                string sKey = kvp.Key;
                if (sKey == "")
                {
                    sKey = "default";
                }
				nmsp.AddNamespace(sKey, kvp.Value);
			}
			return nmsp;
		}
	}
