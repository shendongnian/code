        /// <summary>
        /// Returns latest writen file from the specified directory.
        /// If the directory does not exist or doesn't contain any file, DateTime.MinValue is returned.
        /// </summary>
        /// <param name="directoryInfo">Path of the directory that needs to be scanned</param>
        /// <returns></returns>
        private static DateTime GetLatestWriteTimeFromFileInDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null || !directoryInfo.Exists)
                return DateTime.MinValue;
            FileInfo[] files = directoryInfo.GetFiles();
            DateTime lastWrite = DateTime.MinValue;
            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastWrite)
                {
                    lastWrite = file.LastWriteTime;
                }
            }
            return lastWrite;
        }
        /// <summary>
        /// Returns file's latest writen timestamp from the specified directory.
        /// If the directory does not exist or doesn't contain any file, null is returned.
        /// </summary>
        /// <param name="directoryInfo">Path of the directory that needs to be scanned</param>
        /// <returns></returns>
        private static FileInfo GetLatestWritenFileFileInDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null || !directoryInfo.Exists)
                return null;
            FileInfo[] files = directoryInfo.GetFiles();
            DateTime lastWrite = DateTime.MinValue;
            FileInfo lastWritenFile = null;
            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastWrite)
                {
                    lastWrite = file.LastWriteTime;
                    lastWritenFile = file;
                }
            }
            return lastWritenFile;
        }
