    public async Task<string> DownloadFileAsync(string url, string folder)
    	{
    		var request = WebRequest.Create(url);
    		var response = await request.GetResponseAsync().ConfigureAwait(false);
    		var filename = (response.Headers["Content-Disposition"] ?? "").Replace("attachment; filename=", string.Empty).Replace("\"", string.Empty);
    		
    		if (string.IsNullOrEmpty(filename))
    		{
    			throw new ArgumentException("Cannot be null or empty.", nameof(filename));
    		}
    		
    		var filepath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, folder, filename);
    		var contentStream = response.GetResponseStream();
    		
    		using (var fileStream = File.Create(filepath))
    		{
    			await contentStream.CopyToAsync(fileStream).ConfigureAwait(false);
    		}
    		
    		return filepath;
    	}
