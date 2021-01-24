	public static void Main()
	{
		Console.WriteLine(GetUrl("http://example.org?wID=xxx"));
	}
	
	/// <summary>
    /// Extension method to evaluate the url token for wid
    /// </summary>
    /// <param name="rawUrl">Incoming URL</param>
    /// <returns>Expected URL</returns>
    public static string GetUrl(string rawUrl)
    {
        if (string.IsNullOrWhiteSpace(rawUrl))
        {
            return string.Empty;
        }
		var uriBuilder = new UriBuilder(rawUrl);
        var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.Set("wID", "[[WID]]");
		uriBuilder.Query = queryString.ToString();
		return uriBuilder.Uri.ToString();
    }
