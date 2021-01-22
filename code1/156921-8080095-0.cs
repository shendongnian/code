	// .Dump() is a helper "display" method in LinqPad .Net snippet compiler. 
	// Replace with Console.Write(
	var na = GetCreateXmlNode("a");
			
	na.InnerText = "&lt;b&gt; Dummy value: &lt;/ b&gt;";
	
	na.InnerXml.Dump();
	System.Web.HttpUtility.HtmlDecode(na.InnerXml).Dump();
	na.InnerText.Dump();
	System.Web.HttpUtility.HtmlDecode(na.InnerText).Dump(); // <- Must double-Decode
	na.InnerXml = "&lt;b&gt; Dummy value: &lt;/ b&gt;";
	
	na.InnerXml.Dump();
	System.Web.HttpUtility.HtmlDecode(na.InnerXml).Dump(); // <- or this if you want appearance of "parity"
	na.InnerText.Dump(); // <- just use this
	System.Web.HttpUtility.HtmlDecode(na.InnerText).Dump();
