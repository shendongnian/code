	public static XmlNamespaceManager getAllNamespaces(XmlDocument xDoc)
	{
		XmlNamespaceManager result = new XmlNamespaceManager(xDoc.NameTable);
		IDictionary<string, string> localNamespaces = null;
		XPathNavigator xNav = xDoc.CreateNavigator();
		while (xNav.MoveToFollowing(XPathNodeType.Element))
		{
			localNamespaces = xNav.GetNamespacesInScope(XmlNamespaceScope.Local);
			foreach (var localNamespace in localNamespaces)
			{
				string prefix = localNamespace.Key;
				if (string.IsNullOrEmpty(prefix))
						prefix = "DEFAULT";
				result.AddNamespace(prefix, localNamespace.Value);
			}
		}
		return result;
	}
