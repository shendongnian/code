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
        var result = HttpUtility.ParseQueryString(new Uri(rawUrl).Query).Get("wID");
        return rawUrl.Replace("wID="+result, "wID=[[WID]]");
    }
