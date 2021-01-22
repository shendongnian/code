	using OpenXmlPowerTools;
	using DocumentFormat.OpenXml.Wordprocessing;
	byte[] byteArray = File.ReadAllBytes(DocxFilePath);
	using (MemoryStream memoryStream = new MemoryStream())
	{
		 memoryStream.Write(byteArray, 0, byteArray.Length);
		 using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, true))
		 {
			  HtmlConverterSettings settings = new HtmlConverterSettings()
			  {
				   PageTitle = "My Page Title"
			  };
			  XElement html = HtmlConverter.ConvertToHtml(doc, settings);
			  File.WriteAllText(HTMLFilePath, html.ToStringNewLineOnAttributes());
		 }
	}
