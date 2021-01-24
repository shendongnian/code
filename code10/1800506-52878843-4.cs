    public static bool RenameFileOnServer(string publishUrl, string userName, string userPWD, string sourceFileName, string newFileName)
        {
            bool isNoRenameFile = true;
            int iTentative = 0;
            FtpWebRequest ftpRequest = null;
            FtpWebResponse ftpResponse = null;
            string azureBotUrl = publishUrl + "/" + sourceFileName;
            while (isNoRenameFile)
            {
                iTentative++;
                try
                {
                    ftpRequest = (FtpWebRequest)WebRequest.Create(azureBotUrl);
                    ftpRequest.Credentials = new NetworkCredential(userName, userPWD);
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                    ftpRequest.RenameTo = newFileName.Split('\\')[newFileName.Split('\\').Length - 1];
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ftpResponse.Close();
                    ftpRequest = null;
                    return true;
                }
                catch (WebException webException)
                {
                    FtpWebResponse excWebResponse = (FtpWebResponse)webException.Response;
                    if (excWebResponse.StatusCode == FtpStatusCode.NotLoggedIn)
                    {
                        Console.WriteLine("WebException ==> NotLoggedIn >> Tentative :" + iTentative);
                        isNoRenameFile = true;
                    }
                    else
                    {
                        return false;
                    }
                    Console.WriteLine(webException.Message);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
