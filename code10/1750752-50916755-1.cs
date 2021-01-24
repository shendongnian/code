	foreach(string url in urlList)
	{
		Uri uri = new UriBuilder(url).Uri;
        // Has two segments and no query
		if(uri.Segments.Length == 2 && string.IsNullOrWhiteSpace(uri.Query))
		{
            //Do something
			Console.WriteLine(uri);
		}
	}
