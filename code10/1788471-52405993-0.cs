	var doc = XDocument.Parse(xml);
	var soapNs = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
	var otherNs = XNamespace.Get("http://www...");
	var menuCodes = doc
		.Element(soapNs + "Envelope")
		.Element(soapNs + "Body")
		.Element(otherNs + "GetMenusResponse")
		.Element(otherNs + "GetMenusResult")
		.Element(otherNs + "ResponseBody")
		.Element(otherNs + "Menus")
		.Element(otherNs + "MenuCodes");
