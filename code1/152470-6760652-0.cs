     public bool FtpDirectoryExists(string directoryPath, string ftpUser, string ftpPassword)
            {
                bool IsExists = true;
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(directoryPath);
                    request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                    request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
    
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    IsExists = false;
                }
                return IsExists;
            }
