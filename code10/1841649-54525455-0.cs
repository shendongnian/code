    public static string ReplaceHost(string original, string newHostName)
    {
    	UriBuilder builder = new UriBuilder(original);
    	builder.Host = new Uri(newHostName).Host;
    	return builder.ToString();
    }
