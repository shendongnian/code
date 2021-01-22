    using System.IO;
    
    long GetDirSize(string dir) {
       return new DirectoryInfo(dir)
          .GetFiles("", SearchOption.AllDirectories)
          .Sum(p => p.Length);
    }
