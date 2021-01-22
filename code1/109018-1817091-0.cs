	var stream = new System.IO.StringWriter();
	var xmldoc = new System.Xml.XmlDocument();
	xmldoc.LoadXml("<root><child><grandchild /></child><child /></root>");
	
	var settings = new System.Xml.XmlWriterSettings();
	var propInfo = settings.GetType().GetProperty("OutputMethod");
	propInfo.SetValue(settings, System.Xml.XmlOutputMethod.Html, null);
	var writer = System.Xml.XmlWriter.Create(stream, settings);
	
	xmldoc.Save(writer);
	
	stream.ToString().Dump();
