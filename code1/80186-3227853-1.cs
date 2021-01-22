    public class FtpFileSystemWatcher
    {
        public bool IsRunning
        {
            get;
            private set;
        }
        public string FtpUserName
        {
            get;
            set;
        }
        public string FtpPassword
        {
            get;
            set;
        }
        public string FtpLocationToWatch
        {
            get;
            set;
        }
        public string DownloadTo
        {
            get;
            set;
        }
        public bool KeepOrignal
        {
            get;
            set;
        }
        public bool OverwriteExisting
        {
            get;
            set;
        }
        public int RecheckIntervalInSeconds
        {
            get;
            set;
        }
        private bool DownloadInprogress
        {
            get;
            set;
        }
        private System.Timers.Timer JobProcessor;
        public FtpFileSystemWatcher(string FtpLocationToWatch = "", string DownloadTo = "", int RecheckIntervalInSeconds = 1, string UserName = "", string Password = "", bool KeepOrignal = false, bool OverwriteExisting = false)
        {
            this.FtpUserName = UserName;
            this.FtpPassword = Password;
            this.FtpLocationToWatch = FtpLocationToWatch;
            this.DownloadTo = DownloadTo;
            this.KeepOrignal = KeepOrignal;
            this.RecheckIntervalInSeconds = RecheckIntervalInSeconds;
            this.OverwriteExisting = OverwriteExisting;
            if (this.RecheckIntervalInSeconds < 1) this.RecheckIntervalInSeconds = 1;
        }
        public void StartDownloading()
        {
            JobProcessor = new Timer(this.RecheckIntervalInSeconds * 1000);
            JobProcessor.AutoReset = false;
            JobProcessor.Enabled = false;
            JobProcessor.Elapsed += (sender, e) =>
            {
                try
                {
                    this.IsRunning = true;
                    string[] FilesList = GetFilesList(this.FtpLocationToWatch, this.FtpUserName, this.FtpPassword);
                    if (FilesList == null || FilesList.Length < 1)
                    {
                        return;
                    }
                    foreach (string FileName in FilesList)
                    {
                        if (!string.IsNullOrWhiteSpace(FileName))
                        {
                            DownloadFile(this.FtpLocationToWatch, this.DownloadTo, FileName.Trim(), this.FtpUserName, this.FtpPassword, this.OverwriteExisting);
                            if (!this.KeepOrignal)
                            {
                                DeleteFile(Path.Combine(this.FtpLocationToWatch, FileName.Trim()), this.FtpUserName, this.FtpPassword);
                            }
                        }
                    }
                    this.IsRunning = false;
                    JobProcessor.Enabled = true;                    
                }
                catch (Exception exp)
                {
                    this.IsRunning = false;
                    JobProcessor.Enabled = true;
                    Console.WriteLine(exp.Message);
                }
            };
            JobProcessor.Start();
        }
        public void StopDownloading()
        {
            try
            {
                this.JobProcessor.Dispose();
                this.IsRunning = false;
            }
            catch { }
        }
        private void DeleteFile(string FtpFilePath, string UserName, string Password)
        {
            FtpWebRequest FtpRequest;
            FtpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(FtpFilePath));
            FtpRequest.UseBinary = true;
            FtpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
            FtpRequest.Credentials = new NetworkCredential(UserName, Password);
            FtpWebResponse response = (FtpWebResponse)FtpRequest.GetResponse();
            response.Close();
        }
        private void DownloadFile(string FtpLocation, string FileSystemLocation, string FileName, string UserName, string Password, bool OverwriteExisting)
        {
            try
            {
                const int BufferSize = 2048;
                byte[] Buffer = new byte[BufferSize];
                FtpWebRequest Request;
                FtpWebResponse Response;
                if (File.Exists(Path.Combine(FileSystemLocation, FileName)))
                {
                    if (OverwriteExisting)
                    {
                        File.Delete(Path.Combine(FileSystemLocation, FileName));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("File {0} already exist.", FileName));
                        return;
                    }
                }
                Request = (FtpWebRequest)FtpWebRequest.Create(new Uri(Path.Combine(FtpLocation, FileName)));
                Request.Credentials = new NetworkCredential(UserName, Password);
                Request.Proxy = null;
                Request.Method = WebRequestMethods.Ftp.DownloadFile;
                Request.UseBinary = true;
                Response = (FtpWebResponse)Request.GetResponse();
                using (Stream s = Response.GetResponseStream())
                {
                    using (FileStream fs = new FileStream(Path.Combine(FileSystemLocation, FileName), FileMode.CreateNew, FileAccess.ReadWrite))
                    {
                        while (s.Read(Buffer, 0, BufferSize) != -1)
                        {
                            fs.Write(Buffer, 0, BufferSize);
                        }
                    }
                }
            }
            catch { }
        }
        private string[] GetFilesList(string FtpFolderPath, string UserName, string Password)
        {
            try
            {
                FtpWebRequest Request;
                FtpWebResponse Response;
                Request = (FtpWebRequest)FtpWebRequest.Create(new Uri(FtpFolderPath));
                Request.Credentials = new NetworkCredential(UserName, Password);
                Request.Proxy = null;
                Request.Method = WebRequestMethods.Ftp.ListDirectory;
                Request.UseBinary = true;
                Response = (FtpWebResponse)Request.GetResponse();
                StreamReader reader = new StreamReader(Response.GetResponseStream());
                string Data = reader.ReadToEnd();
                return Data.Split('\n');
            }
            catch
            {
                return null;
            }
        }
    }
