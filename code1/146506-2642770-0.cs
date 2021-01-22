	try
	{
		var n = doc.SelectSingleNode("WhoisRecord/registrant/email");
		if (n == string.Empty) {
			// empty value
		}
		
		// has value
		DoSomething(n.InnerText);
	}
	catch (XPathException)
	{
		// null value.
		throw;
	}
