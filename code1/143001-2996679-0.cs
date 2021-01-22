	public static class WebBrowserExtensions
	{
		public static void Redraw(this WebBrowser browser)
		{
			string temp = Path.GetTempFileName();
			File.WriteAllText(temp, browser.Document.Body.Parent.OuterHtml,
				Encoding.GetEncoding(browser.Document.Encoding));
			browser.Url = new Uri(temp);
		}
	}
