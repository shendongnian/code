        private List<FileInfo> GetLastUpdatedFileInDirectory(DirectoryInfo directoryInfo)
        {
            FileInfo[] files = directoryInfo.GetFiles();
            List<FileInfo> lastUpdatedFile = null;
            DateTime lastUpdate = new DateTime(1, 0, 0);
            foreach (FileInfo file in files)
            {
                if (file.LastAccessTime > lastUpdate)
                {
                    lastUpdatedFile.Add(file);
                    lastUpdate = file.LastAccessTime;
                }
            }
            return lastUpdatedFile;
        }
