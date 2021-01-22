    public class NameComparer : IEqualityComparer<FileInfo>
    {
       public bool Equals(FileInfo x, FileInfo y)
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
    
       public int GetHashCode (FileInfo obj)
       {
          return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.FullName);
       }
    }
