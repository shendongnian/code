    public class Consumer
    {
        private readonly IFileSystemManager fileSystemManager;
        public Consumer(IFileSystemManager fileSystemManager)
        {
            if (fileSystemManager == null)
            {
                throw new ArgumentNullException("fileSystemManager");
            }
            this.fileSystemManager = fileSystemManager;
        }
        // Use the file system manager...
        public void Bar()
        {
            this.fileSystemManager.Manage(someFoo);
        }
    }
