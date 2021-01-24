    public static bool DownloadDocument(string ftpPath, string downloadPath)
    {
        bool retVal = false;
        try
        {
            Uri serverUri = new Uri(ftpPath);
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(ftpPath);
            reqFTP.Credentials = new NetworkCredential(Tools.FtpUserName, Tools.FtpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            reqFTP.UseBinary = true;
            reqFTP.Proxy = null;
            reqFTP.UsePassive = false;
            using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream writeStream = new FileStream(downloadPath, FileMode.Create))
                    {
                        int Length = 1024 * 1024 * 30;
                        Byte[] buffer = new Byte[Length];
                      int byteReads =  responseStream.Read(buffer, 0, Length);
                      while(byteReads > 0)
                      {
                          //Try like this
                          writeStream.Write(buffer, 0, byteReads);
                          bytesRead = responseStream.Read(buffer, 0, Length);
                      }
                       
                    }
                }
            }
            retVal = true;
        }
        catch (Exception ex)
        {
           //Error logging to add
        }
        return retVal;
    }
