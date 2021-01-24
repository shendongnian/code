    public class FileComparer : IEqualityComparer<FileItem>
    {
        public bool Equals(FileItem x, FileItem y)
        {
            return (x.FileID == y.FileID && x.SysCount == y.SysCount && x.SysName == y.SysName);
        }
        public int GetHashCode(FileItem obj)
        {
            unchecked
            {
                int hash = 17;
                if (obj != null)
                {
                    hash = hash * 23 + obj.FileID.GetHashCode();
                    hash = hash * 23 + obj.SysCount.GetHashCode();
                    hash = hash * 23 + obj.SysName.GetHashCode();
                }
                return 0;
            }
        }
    }
