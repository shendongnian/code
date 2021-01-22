    public string LoadFile(string path)
    {
    	stream = GetMemoryStream(path);		
    	string output = TryEncoding(Encoding.UTF8);
    }
    
    public string TryEncoding(Encoding e)
    {
        stream.Seek(0, SeekOrigin.Begin) 
    	StreamReader reader = new StreamReader(stream, e);
    	return reader.ReadToEnd();
    }
    
    private MemoryStream stream = null;
    
    private MemorySteam GetMemoryStream(string path)
    {
    	byte[] buffer = System.IO.File.ReadAllBytes(path);
    	return new MemoryStream(buffer);
    }
