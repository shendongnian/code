    string url = "ftp://ftp.example.com/remote/path/file.txt";
    WebRequest request = WebRequest.Create(url);
    request.Credentials = new NetworkCredential("username", "password");
    request.Method = WebRequestMethods.Ftp.GetFileSize;
    try
    {
        request.GetResponse();
        Console.WriteLine("Exists");
    }
    catch (WebException e)
    {
        FtpWebResponse response = (FtpWebResponse)e.Response;
        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
        {
            Console.WriteLine("Does not exist");
        }
        else
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
