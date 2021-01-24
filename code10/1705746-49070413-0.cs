    internal class FTPManager
    {
        private const string FTPAddress = "ftp://www.example.com:9211/";
        private const string Username = "Yummy";
        private const string Password = "Nachos";
        public byte[] DownloadFile(string relativePath)
        {
            var fileData = new byte[0];
            try
            {
                // parse the path
                relativePath = ParseRelativePath(relativePath);
                using (var request = new WebClient())
                {
                    request.Credentials = new NetworkCredential(Username, Password);
                    fileData = request.DownloadData(FTPAddress + relativePath);
                }
            }
            catch { }
            return fileData;
        }
        public bool DoesFileExist(string relativePath)
        {
            var fileExist = false;
            var request = WebRequest.Create(FTPAddress + ParseRelativePath(relativePath));
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Credentials = new NetworkCredential(Username, Password);
            try
            {
                using (var response = request.GetResponse())
                {
                    fileExist = true;
                }
            }
            catch { }
            return fileExist;
        }
        // upload file and handle everything
        public void UploadFile(string relativePath, byte[] fileBinary)
        {
            // parse the path
            relativePath = ParseRelativePath(relativePath);
            // create the folder before writing the file
            CreateFolders(relativePath);
            // delete the file
            DeleteFile(relativePath);
            // upload the file
            SendFile(relativePath, fileBinary);
        }
        private void SendFile(string relativePath, byte[] fileBinary)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(FTPAddress + relativePath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(Username, Password);
                var stream = request.GetRequestStream();
                var sourceStream = new MemoryStream(fileBinary);
                var length = 1024;
                var buffer = new byte[length];
                var bytesRead = 0;
                do
                {
                    bytesRead = sourceStream.Read(buffer, 0, length);
                    stream.Write(buffer, 0, bytesRead);
                } while (bytesRead != 0);
                sourceStream.Close();
                stream.Close();
            }
            catch 
            {
            }
        }
        private void DeleteFile(string relativePath)
        {
            try
            {
                WebRequest ftpRequest = WebRequest.Create(FTPAddress + relativePath);
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpRequest.Credentials = new NetworkCredential(Username, Password);
                ftpRequest.GetResponse();
            }
            catch { }
        }
        // parse the relative path for strange slashes
        private string ParseRelativePath(string relativePath)
        {
            // split to remove all slashes and duplicates
            var split = relativePath.Split(new string[] { "\\", "/" }, StringSplitOptions.RemoveEmptyEntries);
            // join the string back with valid slash
            var result = String.Join("/", split);
            return result;
        }
        // Check if the relative path need folders to be created
        private void CreateFolders(string relativePath)
        {
            if (relativePath.IndexOf("/") > 0)
            {
                var folders = relativePath.Split(new[] { "/" }, StringSplitOptions.None).ToList();
                var folderToCreate = FTPAddress.Substring(0, FTPAddress.Length - 1);
                for (int i = 0; i < folders.Count - 1; i++)
                {
                    folderToCreate += ("/" + folders[i]);
                    CreateFolder(folderToCreate);
                }
            }
        }
        // create a single folder on the FTP
        private void CreateFolder(string folderPath)
        {
            try
            {
                WebRequest ftpRequest = WebRequest.Create(folderPath);
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftpRequest.Credentials = new NetworkCredential(Username, Password);
                ftpRequest.GetResponse();
            }
            catch { } // create folder will fail if it already exist
        }
    }
