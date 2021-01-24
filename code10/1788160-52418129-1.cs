    public static void DownloadDirectory(
        SftpClient sftpClient, string sourceRemotePath, string destLocalPath)
    {
        Directory.CreateDirectory(destLocalPath);
        IEnumerable<SftpFile> files = sftpClient.ListDirectory(sourceRemotePath);
        foreach (SftpFile file in files)
        {
            if ((file.Name != ".") && (file.Name != ".."))
            {
                string sourceFilePath = sourceRemotePath + "/" + file.Name;
                string destFilePath = Path.Combine(destLocalPath, file.Name);
                if (file.IsDirectory)
                {
                    DownloadDirectory(sftpClient, sourceFilePath, destFilePath);
                }
                else
                {
                    using (Stream fileStream = File.Create(destFilePath))
                    {
                        sftpClient.DownloadFile(sourceFilePath, fileStream);
                    }
                }
            }
        }
    }
