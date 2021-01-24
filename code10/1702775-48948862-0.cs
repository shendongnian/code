	HttpClient client = new HttpClient();
    using (var stream = new MemoryStream())
    {
        // serialize to stream
        ProtoBuf.Serializer.Serialize(stream, List1);
        stream.Seek(0, SeekOrigin.Begin);
        // send data via HTTP
	    StreamContent streamContent = new StreamContent(stream);
	    streamContent.Headers.Add("Content-Type", "application/octet-stream");
	    var response = client.PostAsync("http://what.ever/api/upload", streamContent);
    }
