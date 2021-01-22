    var myString = "This is my <myTag myTagAttrib='colorize'>awesome</myTag> string.";
	try
	{
		var document = XDocument.Parse("<root>" + myString + "</root>");
		var matches = ((System.Collections.IEnumerable)document.XPathEvaluate("myTag|myTag2")).Cast<XElement>();
		foreach (var element in matches)
		{
			switch (element.Name.ToString())
			{
				case "myTag":
					//do something with myTag like lookup attribute values and call other methods
					break;
				case "myTag2":
					//do something else with myTag2
					break;
			}
		}
	}
    catch (Exception e)
	{
		//string was not not well formed xml
	}
