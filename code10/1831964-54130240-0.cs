    public static Task<int> ReadAsync(this Stream stream, 
                                  byte[] buffer, int offset, 
                                  int count)
    {
        if (stream == null) 
           throw new ArgumentNullException("stream");
    
        return Task<int>.Factory.FromAsync(stream.BeginRead, 
                                       stream.EndRead, buffer, 
                                       offset, count, null);
    }
