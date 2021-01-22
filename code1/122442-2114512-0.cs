        public static IEnumerable<FileInfo> BetterFileList(string fileSearchPattern, string rootFolderPath)
        {
            return BetterFileList(fileSearchPattern, new DirectoryInfo(rootFolderPath), 1);
        }
        
        public static IEnumerable<FileInfo> BetterFileList(string fileSearchPattern, DirectoryInfo directory, int depth)
        {
            return depth == 0
                ? directory.GetFiles(fileSearchPattern, SearchOption.TopDirectoryOnly)
                : directory.GetFiles(fileSearchPattern, SearchOption.TopDirectoryOnly).Concat(
                    directory.GetDirectories().SelectMany(x => BetterFileList(fileSearchPattern, x, depth - 1)));
        }
