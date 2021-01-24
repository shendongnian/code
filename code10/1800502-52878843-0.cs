     public static void MakeFTPDir(string publishUrl, string userName, string userPWD, string directory)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;
            string[] subDirs = directory.Split('/');
            string currentDir = publishUrl;
            foreach (string subDir in subDirs)
            {
                try
                {
                    currentDir = currentDir + "/" + subDir;
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    //reqFTP.UsePassive = true;
                    //reqFTP.KeepAlive = true;
                    reqFTP.Credentials = new NetworkCredential(userName, userPWD);
                    FtpWebResponse response =  (FtpWebResponse) reqFTP.GetResponse();
                    while (response.StatusCode == FtpStatusCode.NotLoggedIn)
                    {
                        reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                        reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                        reqFTP.UseBinary = true;
                        //reqFTP.UsePassive = true;
                        //reqFTP.KeepAlive = true;
                        reqFTP.Credentials = new NetworkCredential(userName, userPWD);
                        response = (FtpWebResponse)reqFTP.GetResponse();
                        Console.WriteLine(response.StatusCode);
                    }
                    ftpStream = response.GetResponseStream();
                    ftpStream.Close();
                    response.Close();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
                }
            }
        }
