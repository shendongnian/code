    public class DiskSizeUtil
    {
        /// <summary>
        /// Calculate disk space usage under <paramref name="root"/>.  If <paramref name="levels"/> is provided, 
        /// then return subdirectory disk usages as well, up to <paramref name="levels"/> levels deep.
        /// If levels is not provided or is 0, return a list with a single element representing the
        /// directory specified by <paramref name="root"/>.
        /// </summary>
        /// <returns></returns>
        public static FolderSizeInfo GetDirectorySize(DirectoryInfo root, int levels = 0)
        {
            var currentDirectory = new FolderSizeInfo();
            // Add file sizes.
            FileInfo[] fis = root.GetFiles();
            currentDirectory.Size = 0;
            foreach (FileInfo fi in fis)
            {
                currentDirectory.Size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = root.GetDirectories();
            currentDirectory.Path = root;
            currentDirectory.SizeWithChildren = currentDirectory.Size;
            currentDirectory.DirectoryCount = dis.Length;
            currentDirectory.DirectoryCountWithChildren = dis.Length;
            currentDirectory.FileCount = fis.Length;
            currentDirectory.FileCountWithChildren = fis.Length;
            if (levels >= 0)
                currentDirectory.Children = new List<FolderSizeInfo>();
            foreach (DirectoryInfo di in dis)
            {
                var dd = GetDirectorySize(di, levels - 1);
                if (levels >= 0)
                    currentDirectory.Children.Add(dd);
                currentDirectory.SizeWithChildren += dd.SizeWithChildren;
                currentDirectory.DirectoryCountWithChildren += dd.DirectoryCountWithChildren;
                currentDirectory.FileCountWithChildren += dd.FileCountWithChildren;
            }
            return currentDirectory;
        }
        public class FolderSizeInfo
        {
            public DirectoryInfo Path { get; set; }
            public long SizeWithChildren { get; set; }
            public long Size { get; set; }
            public int DirectoryCount { get; set; }
            public int DirectoryCountWithChildren { get; set; }
            public int FileCount { get; set; }
            public int FileCountWithChildren { get; set; }
            public List<FolderSizeInfo> Children { get; set; }
        }
    }
