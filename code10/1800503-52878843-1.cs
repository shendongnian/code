    public static void MakeFTPDir(string publishUrl, string userName, string userPWD, string directory)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;
            string[] subDirs = directory.Split('/');
            string currentDir = publishUrl;
            foreach (string subDir in subDirs)
            {
                bool isNotCreated = true;
                int iTentative = 0;
                currentDir = currentDir + "/" + subDir;
                while (isNotCreated)
                {
                    iTentative++;
                    try
                    {
                        reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                        reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                        reqFTP.UseBinary = true;
                        reqFTP.UsePassive = true;
                        reqFTP.KeepAlive = true;
                        reqFTP.Credentials = new NetworkCredential(userName, userPWD);
                        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                        ftpStream = response.GetResponseStream();
                        ftpStream.Close();
                        response.Close();
                    }
                    catch(WebException webException)
                    {
                        FtpWebResponse excWebResponse = (FtpWebResponse)webException.Response;
                        if(excWebResponse.StatusCode == FtpStatusCode.NotLoggedIn)
                        {
                            Console.WriteLine("WebException ==> NotLoggedIn >> Tentative :" + iTentative);
                            isNotCreated = true;
                        }
                        else
                        {
                            Console.WriteLine(webException.Message);
                            isNotCreated = false;
                        }
                    }
                    catch (Exception exception)
                    {
                        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                        if (response.StatusCode == FtpStatusCode.NotLoggedIn)
                        {
                            Console.WriteLine("Exception ==> NotLoggedIn >> Tentative :" + iTentative);
                            isNotCreated = true;
                        }
                        else
                        {
                            Console.WriteLine(exception.Message);
                            isNotCreated = false;
                        }
                    }
                }
            }
        }
