    public sealed class FullNameComparer : IEqualityComparer<FileSystemInfo>
    {
        public bool Equals(FileSystemInfo x, FileSystemInfo y)
        {
            if (x == y)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return string.Equals(x.FullName, y.FullName, StringComparison.OrdinalIgnoreCase);
        }
        public int GetHashCode(FileSystemInfo obj)
        {
            return obj.FullName.GetHashCode();
        }
    }
