    public async Task<string> DownloadFileAsync(string url, string folder)
    {
        var request = WebRequest.Create(url);
        var response = await request.GetResponseAsync().ConfigureAwait(false);
        var fileName = string.Empty;
    	
    	if (response.Headers["Content-Disposition"] != null)
    	{
    		var contentDisposition = new System.Net.Mime.ContentDisposition(response.Headers["Content-Disposition"]);
    		
    		if (contentDisposition.DispositionType == "attachment")
    		{
    			fileName = contentDisposition.FileName;
    		}
    	}
    
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentException("Cannot be null or empty.", nameof(fileName));
        }
    	
    	var filePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, folder, fileName);
    
        using (var contentStream = response.GetResponseStream())
        {
            using (var fileStream = File.Create(filePath))
            {
                await contentStream.CopyToAsync(fileStream).ConfigureAwait(false);
            }
        }
    
        return filePath;
    }
