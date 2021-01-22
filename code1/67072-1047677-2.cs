    static byte[] buffer = new byte[100];
    
    static void TestCallbackAPM()
    {
        string filename =
            string.Concat(Environment.SystemDirectory, "\\mfc71.pdb");
    
        FileStream strm = new FileStream(filename,
            FileMode.Open, FileAccess.Read, FileShare.Read, 1024,
            FileOptions.Asynchronous);
    
        // Make the asynchronous call
        IAsyncResult result = strm.BeginRead(buffer, 0, buffer.Length,
            new AsyncCallback(CompleteRead), strm);
    }
