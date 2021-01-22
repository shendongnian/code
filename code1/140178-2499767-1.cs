    string response;
    using (var client = new WebClient()) {
    	byte[] bytes = client.DownloadData(url);
    	using(var reader = new StreamReader(new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress)))
    		response = reader.ReadToEnd();
    }
