    public static string[] getFtpFolderItems(string ftpURL)
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL);
        request.Method = WebRequestMethods.Ftp.ListDirectory;
    
        //You could add Credentials, if needed 
        //request.Credentials = new NetworkCredential("anonymous", "password");
    
        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);
    
        return reader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }
