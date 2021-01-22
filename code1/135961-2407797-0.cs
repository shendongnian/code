    public class Entry
    {
        public string Name { get; private set; }
        public EntryType Type { get; private set; }
        private FileInfo _FileInfo;
        private DirectoryInfo _DirectoryInfo;
        public Entry(FileInfo fileInfo)
        {
            _FileInfo = fileInfo;
            Type = EntryType.FileInfo;
            Name = fileInfo.Name;
        }
        public Entry(DirectoryInfo directoryInfo)
        {
            _DirectoryInfo = directoryInfo;
            Type = EntryType.DirectoryInfo;
            Name = directoryInfo.Name;
        }
        public IEnumerable<Entry> Childs
        {
            get
            {
                if (Type != EntryType.DirectoryInfo
                    || _DirectoryInfo == null)
                {
                    throw new ArgumentNullException();
                }
                foreach (var directory in _DirectoryInfo.GetDirectories())
                {
                    yield return new Entry(directory);
                }
                foreach (var file in _DirectoryInfo.GetFiles())
                {
                    yield return new Entry(file);
                }
            }
        }
        public enum EntryType
        {
            None,
            FileInfo,
            DirectoryInfo
        }
    }
