	public static bool SkipToElement (this XmlReader xmlReader, string elementName)
	{
		if (!xmlReader.Read ())
			return false;
		while (!xmlReader.EOF)
		{
			if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == elementName)
				return true;
			xmlReader.Skip ();
		}
		return false;
	}
