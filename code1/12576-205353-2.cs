	public static bool ContainsXHTML(this string input)
	{
		try
		{
			XElement x = XElement.Parse("<wrapper>" + input + "</wrapper>");
			return !(x.DescendantNodes().Count() == 1 && x.DescendantNodes().First().NodeType == XmlNodeType.Text);
		}
		catch (XmlException ex)
		{
			return true;
		}
	}
