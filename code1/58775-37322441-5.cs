    void DownloadFtpDirectory(string url, NetworkCredential credentials, string localPath)
    {
        FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
        listRequest.UsePassive = true;
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = credentials;
        List<string> lines = new List<string>();
        using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
        using (Stream listStream = listResponse.GetResponseStream())
        using (StreamReader listReader = new StreamReader(listStream))
        {
            while (!listReader.EndOfStream)
            {
                lines.Add(listReader.ReadLine());
            }
        }
        foreach (string line in lines)
        {
            string[] tokens = line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[8];
            string permissions = tokens[0];
            string localFilePath = Path.Combine(localPath, name);
            string fileUrl = url + name;
            if (permissions[0] == 'd')
            {
                Directory.CreateDirectory(localFilePath);
                DownloadFtpDirectory(fileUrl + "/", credentials, localFilePath);
            }
            else
            {
                FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                downloadRequest.UsePassive = true;
                downloadRequest.UseBinary = true;
                downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                downloadRequest.Credentials = credentials;
                using (FtpWebResponse downloadResponse = (FtpWebResponse)downloadRequest.GetResponse())
                using (StreamReader downloadReader = new StreamReader(downloadResponse.GetResponseStream()))
                using (StreamWriter writer = new StreamWriter(localFilePath))
                {
                    writer.Write(downloadReader.ReadToEnd());
                }
            }
        }
    }
