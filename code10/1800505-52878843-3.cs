    public static bool CheckIfFileExistsOnServer(string publishUrl, string userName, string userPWD, string fileName)
        {
            bool isNoCheck = true;
            int iTentative = 0;
            string azureBotUrl = publishUrl + "/" + fileName;
            while (isNoCheck)
            {
                iTentative++;
                try
                {
                    var request = (FtpWebRequest)WebRequest.Create(azureBotUrl);
                    request.Credentials = new NetworkCredential(userName, userPWD);
                    request.UseBinary = true;
                    request.UsePassive = true;
                    request.KeepAlive = true;
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    return true;
                }
                catch (WebException webException)
                {
                    FtpWebResponse excWebResponse = (FtpWebResponse)webException.Response;
                    if (excWebResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        return false;
                    if (excWebResponse.StatusCode == FtpStatusCode.NotLoggedIn)
                    {
                        Console.WriteLine("WebException ==> NotLoggedIn >> Tentative :" + iTentative);
                        isNoCheck = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
