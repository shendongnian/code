	na.InnerText = "<b> Dummy value: </ b>";
	na.InnerXml.Dump();
	System.Web.HttpUtility.HtmlDecode(na.InnerXml).Dump();
	na.InnerText.Dump(); // <- Just use that to get Decoded string.
	System.Web.HttpUtility.HtmlDecode(na.InnerText).Dump();
	&lt;b&gt; Dummy value: &lt;/ b&gt;
	<b> Dummy value: </ b>
	<b> Dummy value: </ b>
	<b> Dummy value: </ b>
