    public static bool UploadFileOnServer(string fileName, Uri serverUri)
    {
        // The URI described by serverUri should use the ftp:// scheme.
        // It contains the name of the file on the server.
        // Example: ftp://contoso.com/someFile.txt. 
        // The fileName parameter identifies the file 
        // to be uploaded to the server.
        
        if (serverUri.Scheme != Uri.UriSchemeFtp)
        {
            return false;
        }
        // Get the object used to communicate with the server.
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
        request.Method = WebRequestMethods.Ftp.UploadFile;
        
        StreamReader sourceStream = new StreamReader(fileName);
        byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
        sourceStream.Close();
        request.ContentLength = fileContents.Length;
     
        // This example assumes the FTP site uses anonymous logon.
        request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(fileContents, 0, fileContents.Length);
        requestStream.Close();
        FtpWebResponse response = (FtpWebResponse) request.GetResponse();
        
        Console.WriteLine("Upload status: {0}",response.StatusDescription);
        
        response.Close();  
        return true;
    }
