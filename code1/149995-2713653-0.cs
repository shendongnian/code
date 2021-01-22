    struct AllDirectories {
      public List<string> DirectoriesWithoutFiles { get; set; }
      public List<string> DirectoriesWithFiles { get; set; }
    }
    static class FileSystemScanner {
      public AllDirectories DivideDirectories(string startingPath) {
        var startingDir = new DirectoryInfo(startingPath);
        // allContent IList<FileSystemInfo>
        var allContent = GetAllFileSystemObjects(startingDir);
        var allFiles = allContent.Where(f => !(f.Attributes & FileAttributes.Directory))
                                 .Cast<FileInfo>();
        var dirs = allContent.Where(f => (f.Attributes & FileAttributes.Directory))
                             .Cast<DirectoryInfo>();
        var allDirs = new SortedList<DirectoryInfo>(dirs, new FileSystemInfoComparer());
        var res = new AllDirectories {
          DirectoriesWithFiles = new List<string>()
        };
        foreach (var file in allFiles) {
          var dirName = Path.GetDirectoryName(file.Name);
          if (allDirs.Remove(dirName)) {
            // Was removed, so first time this dir name seen.
            res.DirectoriesWithFiles.Add(dirName);
          }
        }
        // allDirs now just contains directories without files
        res.DirectoriesWithoutFiles = new List<String>(addDirs.Select(d => d.Name));
      }
      class FileSystemInfoComparer : IComparer<FileSystemInfo> {
        public int Compare(FileSystemInfo l, FileSystemInfo r) {
          return String.Compare(l.Name, r.Name, StringComparison.OrdinalIgnoreCase);
        }
      }
    }
