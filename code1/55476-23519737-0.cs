    public static void MakeFTPDir(string ftpAddress, string pathToCreate, string login, string password, byte[] fileContents, string ftpProxy = null)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;
            string[] subDirs = pathToCreate.Split('/');
            string currentDir = string.Format("ftp://{0}", ftpAddress);
            foreach (string subDir in subDirs)
            {
                try
                {
                    currentDir = currentDir + "/" + subDir;
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(login, password);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                    ftpStream.Close();
                    response.Close();
                }
                catch (Exception ex)
                {
                    //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
                }
            }
        }
