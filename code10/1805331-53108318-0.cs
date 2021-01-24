    public class LocalFolder
    {
        public string FolderPath { get; }
        public IEnumerable<LocalFile> FolderFiles { get; }
        public LocalFolder(string folderPath, IEnumerable<LocalFile> files)
        {
            this.FolderPath = folderPath ?? throw new ArgumentNullException(nameof(folderPath));
            this.FolderFiles = files ?? throw new ArgumentNullException(nameof(files));
        }
    }
