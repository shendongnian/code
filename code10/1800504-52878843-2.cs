     public static bool SendFtpFile(string publishUrl, string userName, string userPWD, string localFileName)
        {
            bool isNotCreated = true;
            int iTentative = 0;
            while (isNotCreated)
            {
                iTentative++;
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(userName, userPWD);
                        client.UploadFile(publishUrl, "STOR", localFileName);
                        return true;
                    }
                }
                catch (WebException webException)
                {
                    FtpWebResponse excWebResponse = (FtpWebResponse)webException.Response;
                    if (excWebResponse.StatusCode == FtpStatusCode.NotLoggedIn)
                    {
                        Console.WriteLine("WebException ==> NotLoggedIn >> Tentative :" + iTentative);
                        isNotCreated = true;
                    }
                    else
                    {
                        Console.WriteLine(webException.Message);
                        return false;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return false;
                }
            }
            return true;
        }
