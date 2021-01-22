    public class FileNameComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            return Equals(x.Name, y.Name);
        }
        public int GetHashCode(FileInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }     
