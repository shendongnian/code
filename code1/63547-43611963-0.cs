    private static void RemoveDefNamespace(XElement element)
	{
		var defNamespase = element.Attribute("xmlns");
		if (defNamespase != null)
			defNamespase.Remove();
		element.Name = element.Name.LocalName;
		foreach (var child in element.Elements())
		{
			RemoveDefNamespace(child);
		}
	}
