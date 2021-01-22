    private bool isValidConnection(string url, string user, string password)
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    request.Credentials = new NetworkCredential(user, password);
                    request.GetResponse();
                }
                catch(WebException ex)
                {
                    return false;
                }
                return true;
            }
