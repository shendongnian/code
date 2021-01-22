        public static int FolderDepth(string path)
        {
            if (string.IsNullOrEmpty(path))
                return 0;
            return FolderDepth(new DirectoryInfo(path));
        }
        public static int FolderDepth(DirectoryInfo directory)
        {
            if (directory == null)
                return 0;
            return FolderDepth(directory.Parent) + 1;
        }
