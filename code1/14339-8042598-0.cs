    const int BUFFER_SIZE = 4096;
    
    static byte[] bufferForRead = new byte[BUFFER_SIZE];
    static byte[] bufferForWrite = new byte[BUFFER_SIZE];
    
    static Stream sourceStream = new MemoryStream();
    static Stream destinationStream = new MemoryStream();
    
    static void Main(string[] args)
    {
        // Initial read from source stream
        sourceStream.BeginRead(bufferForRead, 0, BUFFER_SIZE, BeginReadCallback, null);
    }
    
    private static void BeginReadCallback(IAsyncResult asyncRes)
    {
        // Finish reading from source stream
        int bytesRead = sourceStream.EndRead(asyncRes);
        // Make a copy of the buffer as we'll start another read immediately
        Array.Copy(bufferForRead, 0, bufferForWrite, 0, bytesRead);
        // Write copied buffer to destination stream
        destinationStream.BeginWrite(bufferForWrite, 0, bytesRead, BeginWriteCallback, null);
        // Start the next read (looks like async recursion I guess)
        sourceStream.BeginRead(bufferForRead, 0, BUFFER_SIZE, BeginReadCallback, null);
    }
    
    private static void BeginWriteCallback(IAsyncResult asyncRes)
    {
        // Finish writing to destination stream
        destinationStream.EndWrite(asyncRes);
    }
