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
            return String.Equals(x.FullName.TrimEnd('\\'), y.FullName.TrimEnd('\\'), StringComparison.OrdinalIgnoreCase);
        }
        public int GetHashCode(FileSystemInfo obj)
        {
            return obj.FullName.GetHashCode();
        }
    }
