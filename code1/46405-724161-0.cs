      static List<Info> RecursiveMovieFolderScan1() {
          var info = new List<Info>();
          var dirInfo = new DirectoryInfo(path);
          RecursiveMovieFolderScan(dirInfo, info);
          return info;
      } 
      static List<Info> RecursiveMovieFolderScan(DirectoryInfo dirInfo, List<Info> info){
        foreach (var dir in dirInfo.GetDirectories()) {
            info.Add(new Info() {
                IsDirectory = true,
                CreatedDate = dir.CreationTimeUtc,
                ModifiedDate = dir.LastWriteTimeUtc,
                Path = dir.FullName
            });
            RecursiveMovieFolderScan(dir, info);
        }
        foreach (var file in dirInfo.GetFiles()) {
            info.Add(new Info()
            {
                IsDirectory = false,
                CreatedDate = file.CreationTimeUtc,
                ModifiedDate = file.LastWriteTimeUtc,
                Path = file.FullName
            });
        }
        return info; 
    }
