	/// <summary>Same as XElement.Parse(), but supports XML namespaces.</summary>
	/// <param name="strXml">A String that contains XML.</param>
	/// <param name="mngr">The XmlNamespaceManager to use for looking up namespace information.</param>
	/// <returns>An XElement populated from the string that contains XML.</returns>
	public static XElement ParseElement( string strXml, XmlNamespaceManager mngr )
	{
		XmlParserContext parserContext = new XmlParserContext( null, mngr, null, XmlSpace.None );
		XmlTextReader txtReader = new XmlTextReader( strXml, XmlNodeType.Element, parserContext );
		return XElement.Load( txtReader );
	}
