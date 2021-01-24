    public class MainFolderDisplay
    {
            public MainFolderDisplay()
            {
                StorageFileDisplay = new List<StorageFileDisplay>();
                SubFolderDisplay = new List<SubFolderDisplay>();
            }
            public int MainFolderId { get; set; }
            public string MainFolderName { get; set; }
            public int UserId { get; set; }
    
            public List<StorageFileDisplay> StorageFileDisplay { get; set; }
            public List<SubFolderDisplay> SubFolderDisplay { get; set; }
    }
