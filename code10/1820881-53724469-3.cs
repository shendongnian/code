    class ListItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public ListItem(string filename, string fullpath )
        { Name = filename; FullPath = fullpath; }
        override public string ToString() { return Name; }
    }
