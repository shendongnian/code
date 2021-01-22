    protected override void PrintDocument(XmlDocument document, string xsltFileName, string directory, string tempImageDirectory)
    {
        StringUtils.EscapeQuotesInXmlNode(document);
	if (RemoveDiatrics)
	{
	    var docXml = StringUtils.RemoveDiatrics(document.OuterXml);
	    document = new XmlDocument();
	    document.LoadXml(docXml);
	}
	IOException ex = null;
	for (var attempts = 0; attempts < 10; attempts++)
	{
	    ex = tryWriteToFile(document, directory, xsltFileName);
	    if (ex == null)
	        break;
	}
			
	if (ex != null)
	    throw new ApplicationException("Cannot write to file", ex);
    }
    private IOException tryWriteToFile(XmlDocument document, string directory, string xsltFileName)
    {
	try
	{
	    using (var writer = new StreamWriter(new FileStream(string.Format("{0}{1}{2}", directory, "batch", FileExtension), FileMode.Append, FileAccess.Write, FileShare.Read), Encoding.ASCII))
	    {
	        Transform(document, xsltFileName, writer);
		writer.Close();
	    }
	    return null;
	}
	catch (IOException e)
	{
	    return e;
	}
    }
