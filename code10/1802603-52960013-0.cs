    private static void TestWrite()
    { 
       // Must specify FileOptions.Asynchronous otherwise the BeginXxx/EndXxx methods are
       // handled synchronously.
       FileStream fs = new FileStream(Program.FilePath, FileMode.OpenOrCreate,
          FileAccess.Write, FileShare.None, 8, FileOptions.Asynchronous);
    
       string content = "A quick brown fox jumps over the lazy dog";
       byte[] data = Encoding.Unicode.GetBytes(content);
    
       // Begins to write content to the file stream.
       Console.WriteLine("Begin to write");
       fs.BeginWrite(data, 0, data.Length, Program.OnWriteCompleted, fs);
       Console.WriteLine("Write queued");
    }
    
    private static void OnWriteCompleted(IAsyncResult asyncResult)
    { 
       // End the async operation.
       FileStream fs = (FileStream)asyncResult.AsyncState;
       fs.EndWrite(asyncResult);
    
       // Close the file stream.
       fs.Close();
       Console.WriteLine("Write completed");
    
       // Test async read bytes from the file stream.
       Program.TestRead();
    }
