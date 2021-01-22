    var myString = "This is my <myTag myTagAttrib='colorize'>awesome</myTag> string.";
	try
	{
		var document = XDocument.Parse("<root>" + myString + "</root>");
		var matches = ((IEnumerable)document.XPathEvaluate("//myTag/@myTagAttrib|//myTag2/@someotherattribute")).Cast<XAttribute>();
		foreach (var attribute in matches)
		{
			string attributeValue = attribute.Value;
			string elmentValue = attribute.Parent.Value;
		}
	}
	catch (Exception e)
	{
		//string was not not well formed xml
	}
