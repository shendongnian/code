    static void CompleteRead(IAsyncResult result)
    {
        Console.WriteLine("Read Completed");
    
        FileStream strm = (FileStream) result.AsyncState;
    
        // Finished, so we can call EndRead and it will return without blocking
        int numBytes = strm.EndRead(result);
    
        // Don't forget to close the stream
        strm.Close();
    
        Console.WriteLine("Read {0} Bytes", numBytes);
        Console.WriteLine(BitConverter.ToString(buffer));
    }
