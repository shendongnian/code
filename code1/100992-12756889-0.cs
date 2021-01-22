    /// <summary>
    /// Remove illegal XML characters from a string.
    /// </summary>
    public string SanitizeXmlString(string xml)
    {
	if (xml == null)
	{
		throw new ArgumentNullException("xml");
	}
	
	StringBuilder buffer = new StringBuilder(xml.Length);
	
	foreach (char c in xml)
	{
		if (IsLegalXmlChar(c))
		{
			buffer.Append(c);
		}
	}
		
	return buffer.ToString();
    }
    /// <summary>
    /// Whether a given character is allowed by XML 1.0.
    /// </summary>
    public bool IsLegalXmlChar(int character)
    {
	return
	(
		 character == 0x9 /* == '\t' == 9   */          ||
		 character == 0xA /* == '\n' == 10  */          ||
		 character == 0xD /* == '\r' == 13  */          ||
		(character >= 0x20    && character <= 0xD7FF  ) ||
		(character >= 0xE000  && character <= 0xFFFD  ) ||
		(character >= 0x10000 && character <= 0x10FFFF)
	);
    }
