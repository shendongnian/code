    static int CHUNK_SIZE = 4096;
    
    // open the file
    FileStream stream = File.OpenRead("path\to\file");
    
    // send by chunks
    byte[] data = new byte[CHUNK_SIZE];
    int numBytesRead = CHUNK_SIZE;
    while ((numBytesRead = stream.Read(data, 0, CHUNK_SIZE)) > 0)
    {
        // resize the array if we read less than requested
        if (numBytesRead < CHUNK_SIZE)
            Array.Resize(data, numBytesRead);
        
        // pass the chunk to the server
        server.GiveNextChunk(data);
        // re-init the array so it's back to the original size and cleared out.
        data = new byte[CHUNK_SIZE];
    }
    
    // an example of how to let the server know the file is done so it can close
    // the receiving stream on its end.
    server.GiveNextChunk(null);
    
    // close our stream too
    stream.Close();
