	na.InnerText = "<b> Dummy value: </ b>";
	na.InnerXml.Dump();
	System.Web.HttpUtility.HtmlDecode(na.InnerXml).Dump();
	na.InnerText.Dump(); // <- Just use that to get Decoded string.
	System.Web.HttpUtility.HtmlDecode(na.InnerText).Dump();
	&lt;b&gt; Dummy value: &lt;/ b&gt;  // raw xml contents
	<b> Dummy value: </ b> // single-encoding, single-decoding, but too messy.
	<b> Dummy value: </ b> // single-encoding, single-decoding
	<b> Dummy value: </ b> // single-encoding, double-decoding
