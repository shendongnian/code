    private static string FindWebSiteByName(string serverName, string webSiteName)
	{
		DirectoryEntry w3svc = new DirectoryEntry("IIS://" + serverName + "/W3SVC");
		foreach (DirectoryEntry site in w3svc.Children)
		{
			if (site.SchemaClassName == "IIsWebServer"
				&& site.Properties["ServerComment"] != null
				&& site.Properties["ServerComment"].Value != null
				&& string.Equals(webSiteName, site.Properties["ServerComment"].Value.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return site.Name;
			}
		}
		
		return null;
	}
