        static List<Info> RecursiveScan3(string path)
        {
            var info = new List<Info>();
            var dirInfo = new DirectoryInfo(path);
            foreach (var entry in dirInfo.EnumerateFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Add(new Info()
                {
                    IsDirectory = (entry.Attributes & FileAttributes.Directory) != 0,
                    CreatedDate = entry.CreationTimeUtc,
                    ModifiedDate = entry.LastWriteTimeUtc,
                    Path = entry.FullName
                });
            }
            return info;
        }
