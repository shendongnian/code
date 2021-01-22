    public string StripHTML(string html)
    {
    	var regex = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
    	return System.Web.HttpUtility.HtmlDecode((regex.Replace(html, "")));
    }
