	/// <summary>
	/// Sets the default XML namespace of this System.Xml.Linq.XElement
	/// and all its descendants
	/// </summary>
	public static void SetDefaultNamespace(this XElement element, XNamespace newXmlns)
	{
		var currentXmlns = element.GetDefaultNamespace();
		if (currentXmlns == newXmlns)
			return;
		foreach (var descendant in element.DescendantsAndSelf()
			.Where(e => e.Name.Namespace == currentXmlns)) //!important
		{
			descendant.Name = newXmlns.GetName(descendant.Name.LocalName);
		}
	}
