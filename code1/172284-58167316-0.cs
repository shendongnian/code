      public async Task<bool> ConnectAsync(string host, string user, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host);
                request.Credentials = new NetworkCredential(user, password);
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false; // useful when only to check the connection.
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse) await _ftpRequest.GetResponseAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
