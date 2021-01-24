	private string ConvertToken(string html)
	{
		var doc = new HtmlAgilityPack.HtmlDocument();
		doc.LoadHtml(html);
		var timeout = DateTime.Now + TimeSpan.FromSeconds(5);
		dynamic obj = null;
		while (obj == null && DateTime.Now < timeout)
		{
			try
			{
				obj = (dynamic)JsonConvert.DeserializeObject(doc.DocumentNode.InnerText);
			}
			catch (Exception ex)
			{
				// Firefox occasionally bugs out if its JSON viewer kicks in too early, so use the according elements if needed
				var element = Driver.FindElementById("rawdata-tab");
				Driver.ClickElement(element);
				var text = Driver.FindElementByClassName("data").Text;
				obj = (dynamic)JsonConvert.DeserializeObject(text);
			}
		}
		return obj[0]["access_token"].ToString();
	}
