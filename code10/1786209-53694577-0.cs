	var config = Configuration.Default.WithDefaultLoader().WithCss();
	var parser = new HtmlParser(config);
	var document = parser.Parse("<p><span><span><em>span text</em></span> </span> span text</p>");
	
	foreach (var element in document.QuerySelectorAll("span").Where(m => m.Attributes.Length == 0))
	{
		element.Replace(element.ChildNodes.ToArray());
	}
	document.Body.InnerHtml.Dump();
