        static List<Info> RecursiveMovieFolderScan(string path)
        {
            var info = new List<Info>();
            var dirInfo = new DirectoryInfo(path);
            foreach (var entry in dirInfo.GetFileSystemInfos())
            {
                bool isDir = (entry.Attributes & FileAttributes.Directory) != 0;
                if (isDir)
                {
                    info.AddRange(RecursiveMovieFolderScan(entry.FullName));
                }
                info.Add(new Info()
                {
                    IsDirectory = isDir,
                    CreatedDate = entry.CreationTimeUtc,
                    ModifiedDate = entry.LastWriteTimeUtc,
                    Path = entry.FullName
                });
            }
            return info;
        }
