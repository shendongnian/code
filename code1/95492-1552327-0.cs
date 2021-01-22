        public static IEnumerable<FileSystemInfo> GetAllFilesAndDirectories(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            Stack<FileSystemInfo> stack = new Stack<FileSystemInfo>();
            stack.Push(dirInfo);
            while (stack.Count > 0)
            {
                FileSystemInfo fileSystemInfo = stack.Pop();
                DirectoryInfo subDirectoryInfo = fileSystemInfo as DirectoryInfo;
                if (subDirectoryInfo != null)
                {
                    yield return subDirectoryInfo;
                    foreach (FileSystemInfo fsi in subDirectoryInfo.GetFileSystemInfos())
                    {
                        stack.Push(fsi);
                    }
                }
                else
                {
                    yield return fileSystemInfo;
                }
            }
        }
