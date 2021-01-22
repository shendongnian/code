    class Example
    {
        public List<FileInfo> FileList { get; set; }
        public Dictionary<string, FileInfo> Files { get; set; }
    
        public Example()
        {
            FileList = new List<FileInfo>();
            Files = new Dictionary<string, FileInfo>();
        }
    
    }
