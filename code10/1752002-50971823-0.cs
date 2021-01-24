	public static string ModifyUrlParameters(string rawUrl, string key, string val)
	{
		if (string.IsNullOrWhiteSpace(rawUrl))
		{
			return string.Empty;
		}
		
		//Builds a URI from your string
		var uriBuilder = new UriBuilder(rawUrl);		
		
		//Gets the query string as a NameValueCollection
		var queryItems = HttpUtility.ParseQueryString(uriBuilder.Uri.Query);
		
		//Sets the key with the new val
		queryItems.Set(key, val);
		
		//Sets the query to the new updated query
		uriBuilder.Query = queryItems.ToString();
		
		//returns the uri as a string
		return uriBuilder.Uri.ToString();
	}
