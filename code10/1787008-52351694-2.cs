    public class MainFolderDisplay
    {
        private List<StorageFile> _storageFile;
        public int MainFolderId { get; set; }
        public string MainFolderName { get; set; }
        public int UserId { get; set; }
        public List<StorageFile> StorageFile
        {
            get => _storageFile ?? (_storageFile = new List<StorageFile>());
            set => _storageFile = value;
        }
    }
