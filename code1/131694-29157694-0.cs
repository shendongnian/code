        public static void DeleteDirectory(string path)
        {
            var directory = new DirectoryInfo(path) 
            { Attributes =FileAttributes.Normal };
            foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Attributes = FileAttributes.Normal;
            }
            directory.Delete(true);
        }
