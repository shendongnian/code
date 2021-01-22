cs
public static string TransformDocument(string doc, string stylesheetPath)
{
	Func<string,XmlDocument> GetXmlDocument = (xmlContent) =>
	 {
		 XmlDocument xmlDocument = new XmlDocument();
		 xmlDocument.LoadXml(xmlContent);
		 return xmlDocument;
	 };
	try
	{
		var document = GetXmlDocument(doc);
		var style = GetXmlDocument(File.ReadAllText(stylesheetPath));
		System.Xml.Xsl.XslCompiledTransform transform = new System.Xml.Xsl.XslCompiledTransform();
		transform.Load(style); // compiled stylesheet
		System.IO.StringWriter writer = new System.IO.StringWriter();
		XmlReader xmlReadB = new XmlTextReader(new StringReader(document.DocumentElement.OuterXml));
		transform.Transform(xmlReadB, null, writer);
		return writer.ToString();
	}
	catch (Exception ex)
	{
		throw ex;
	}
}	
