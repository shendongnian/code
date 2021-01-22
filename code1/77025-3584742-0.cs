	/// <summary>Same as XElement.Parse(), but supports XML namespaces.</summary>
	/// <param name="strXml">A System.String that contains XML.</param>
	/// <param name="mngr">The System.Xml.XmlNamespaceManager to use for looking up namespace information.</param>
	/// <returns>An System.Xml.Linq.XElement populated from the string that contains XML.</returns>
	// The XML namespaces support in the framework feels f*****' under-engineered.
	public static XElement ParseElement( string strXml, XmlNamespaceManager mngr )
	{
		XmlParserContext parserContext = new XmlParserContext( null, mngr, null, XmlSpace.None );
		XmlTextReader txtReader = new XmlTextReader( strXml, XmlNodeType.Element, parserContext );
		return XElement.Load( txtReader );
	}
