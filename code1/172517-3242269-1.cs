    public static class TempFileManager
    {
        private static readonly List<FileInfo> TempFiles = new List<FileInfo>();
        private static readonly object SyncObj = new object();
        static TempFileManager()
        {
            AppDomain.CurrentDomain.DomainUnload += CurrentDomainDomainUnload;
        }
        private static void CurrentDomainDomainUnload(object sender, EventArgs e)
        {
            TempFiles.FindAll(file => File.Exists(file.FullName)).ForEach(file => file.Delete());
        }
        public static FileInfo CreateTempFile(bool autoDelete)
        {
            FileInfo tempFile = new FileInfo(Path.GetTempFileName());
            if (autoDelete)
            {
                lock (SyncObj)
                {
                    TempFiles.Add(tempFile);
                }
            }
            return tempFile;
        }
    }
