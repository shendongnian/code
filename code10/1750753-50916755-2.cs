	public static bool IsMatch(string url)
	{
		Uri uri = new UriBuilder(url).Uri;
		return uri.Segments.Length == 2 && string.IsNullOrWhiteSpace(uri.Query);
	}
