    using System.IO;
    public static class FileSystemInfoExtensions
    {
        /// <summary>
        /// Checks whether a FileInfo or DirectoryInfo object is a directory, or intended to be a directory.
        /// </summary>
        /// <param name="fileSystemInfo"></param>
        /// <returns></returns>
        public static bool IsDirectory(this FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo == null)
            {
                return false;
            }
            if ((int)fileSystemInfo.Attributes != -1)
            {
                // if attributes are initialized check the directory flag
                return fileSystemInfo.Attributes.HasFlag(FileAttributes.Directory);
            }
            // If we get here the file probably doesn't exist yet.  The best we can do is 
            // try to judge intent.  Because directories can have extensions and files
            // can lack them, we can't rely on filename.
            // 
            // We can reasonably assume that if the path doesn't exist yet and 
            // FileSystemInfo is a DirectoryInfo, a directory is intended.  FileInfo can 
            // make a directory, but it would be a bizarre code path.
            return fileSystemInfo is DirectoryInfo;
        }
    }
