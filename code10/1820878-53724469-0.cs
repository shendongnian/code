    class ListItem
    {
        string Name { get; set; }
        string FullPath { get; set; }
        public ListItem(string filename, string fullpath )
        { Name = filename; FullPath = fullpath; }
        public string ToString() { return Name; }
    }
