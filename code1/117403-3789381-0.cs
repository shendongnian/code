    private bool CreateFTPDirectory(string directory)
    {
        try
        {
            //create the directory
            FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(FtpURI+"/"+directory));
            requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
            requestDir.UsePassive = true;
            requestDir.UseBinary = true;
            requestDir.KeepAlive = false;
            //requestDir.UseDefaultCredentials = true;
            requestDir.Credentials = new NetworkCredential(UserId, Password);
            requestDir.Proxy = WebRequest.DefaultWebProxy;
            requestDir.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            ftpStream.Close();
            response.Close();
            return true;
        }
        catch (WebException ex)
        {
            FtpWebResponse response = (FtpWebResponse)ex.Response;
            if ((response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) || (((int)response.StatusCode)==521))
            {
                response.Close();
                return true;
            }
            else
            {
                response.Close();
                return false;
            }
        }
    }
        
