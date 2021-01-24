    class ListItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public ListItem(string filename, string fullpath )
        { Name = filename; FullPath = fullpath; }
        public ListItem(FileInfo fileinfo )
        { Name = fileinfo.Name; FullPath = fileinfo.FullName; }
        override public string ToString() { return Name; }
    }
