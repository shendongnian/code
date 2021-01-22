    public class FileListComparer : IEqualityComparer<FileList>
    {
        public bool Equals(FileList x, FileList y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            return x.FileNames.Equals(y.FileNames, StringComparison.OrdinalIgnoreCase);
        }
        public int GetHashCode(FileList obj) { return base.GetHashCode(); }
    }
