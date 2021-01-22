    public class DiskSizeUtil
    {
        public class FolderSizeInfo
        {
            public DirectoryInfo Path;
            public long SizeWithChildren;
            public long Size;
            public int DirectoryCount;
            public int DirectoryCountWithChildren;
            public override string ToString()
            {
                return string.Format("{1,10} {2,10} {3,3} {4,3} {0}", this.Path.FullName, this.Size, this.SizeWithChildren, this.DirectoryCount, this.DirectoryCountWithChildren);
            }
        }
        private static FolderSizeInfo GetDirectorySize(DirectoryInfo d, List<FolderSizeInfo> data, int levels)
        {
            var currentDirectory = new FolderSizeInfo();
            if (levels >= 0)
                data.Add(currentDirectory);
            long Size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            currentDirectory.Size = Size;
            currentDirectory.Path = d;
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            currentDirectory.DirectoryCount = dis.Length;
            currentDirectory.DirectoryCountWithChildren = dis.Length;
            foreach (DirectoryInfo di in dis)
            {
                var dd = GetDirectorySize(di, data, levels - 1);
                Size += dd.SizeWithChildren;
                currentDirectory.DirectoryCountWithChildren += dd.DirectoryCountWithChildren;
            }
            currentDirectory.SizeWithChildren = Size;
            return currentDirectory;
        }
        /// <summary>
        /// Calculate disk space usage under <paramref name="root"/>.  If <paramref name="levels"/> is provided, 
        /// then return subdirectory disk usages as well, up to <paramref name="level"/> levels deep.
        /// If levels is not provided or is 0, return a list with a single element representing the
        /// directory specified by <paramref name="root"/>.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="levels"></param>
        /// <returns></returns>
        public static List<FolderSizeInfo> GetDirectorySize(DirectoryInfo root, int levels = 0)
        {
            var data = new List<FolderSizeInfo>();
            GetDirectorySize(root, data, levels);
            return data;
        }
