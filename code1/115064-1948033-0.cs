    class FileInfoItem {
        public FileInfoItem(FileInfo info) {
            Info = info;
        }
    
        public FileInfo Info { get; set; }
    
        public override string ToString() {
            return Info.Name;
        }
    }
