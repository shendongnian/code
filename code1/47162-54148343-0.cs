    public string HtmlFileToText(string filePath)
    {
    	using (var browser = new WebBrowser())
    	{
    		string text = File.ReadAllText(filePath);
    		browser.ScriptErrorsSuppressed = true;
    		browser.Navigate("about:blank");
    		browser?.Document?.OpenNew(false);
    		browser?.Document?.Write(text);
    		return browser.Document?.Body?.InnerText;
    		//return browser.Document?.Body?.InnerText.Replace(Environment.NewLine, "<br />");
    	}	
    }
