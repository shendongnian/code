    public void DownloadFile(string url, string toLocalPath)
    {
        byte[] result = null;
        byte[] buffer = new byte[4097];
        
        WebRequest wr = WebRequest.Create(url);
        
        WebResponse response = wr.GetResponse();
        Stream responseStream = response.GetResponseStream;
        MemoryStream memoryStream = new MemoryStream();
        
        int count = 0;
        
        do {
            count = responseStream.Read(buffer, 0, buffer.Length);
            memoryStream.Write(buffer, 0, count);
            
            if (count == 0) {
                break;
            }
        }
        while (true);
        
        result = memoryStream.ToArray;
        
        FileStream fs = new FileStream(toLocalPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        
        fs.Write(result, 0, result.Length);
        
        fs.Close();
        memoryStream.Close();
        responseStream.Close();
    }
