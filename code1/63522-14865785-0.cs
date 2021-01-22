	foreach (XElement XE in Xml.DescendantsAndSelf())
	{
		// Stripping the namespace by setting the name of the element to it's localname only
		XE.Name = XE.Name.LocalName;
		// replacing all attributes with attributes that are not namespaces and their names are set to only the localname
		XE.ReplaceAttributes((from xattrib in XE.Attributes().Where(xa => !xa.IsNamespaceDeclaration) select new XAttribute(xattrib.Name.LocalName, xattrib.Value)));
	}
