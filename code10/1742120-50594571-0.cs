    public MemoryStream GetFileStream(string filePath, string userName, string password)
    {
        Console.WriteLine($"getting file stream : {filePath}");
        MemoryStream ftpStream = null;
        try
        {
            var fileName = Guid.NewGuid().ToString();
    
            FtpWebRequest request = WebRequest.Create(filePath) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(userName, password);
    
            ftpStream = new MemoryStream();
            ...
            ftpStream.Position = 0; // <-- ADD THIS LINE
        }
        catch (Exception ex)
        {
            Console.WriteLine($"getting file stream : {filePath} " + ex.ToString());
        }
    
        return ftpStream;
    }
