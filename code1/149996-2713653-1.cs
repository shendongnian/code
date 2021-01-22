    ILIst<FileSystemInfo> GetAllFileSystemObjects(DirectoryInfo root) {
      var res = new List<FileSystemInfo>();
      var pending = new Queue<DirectoryInfo>(new [] { root });
      while (pending.Count > 0) {
        var dir = pending.Dequeue();
        var content = dir.GetFileSystemInfos();
        res.AddRange(content);
        foreach (var dir in content.Where(f => (f.Attributes & FileAttributes.Directory))
                                   .Cast<DirectoryInfo>()) {
          pending.Enqueue(dir);
        }
      }
      return res;
    }
