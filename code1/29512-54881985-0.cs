    private static long DirectorySize(SortDirection sortDirection, DirectoryInfo directoryInfo, DirectoryData directoryData)
    {
            long directorySizeBytes = 0;
            // Add file sizes for current directory
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            foreach (FileInfo fileInfo in fileInfos)
            {
                directorySizeBytes += fileInfo.Length;
            }
            directoryData.Name = directoryInfo.Name;
            directoryData.SizeBytes += directorySizeBytes;
            // Recursively add subdirectory sizes
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo di in subDirectories)
            {
                var subDirectoryData = new DirectoryData(sortDirection);
                directoryData.DirectoryDatas.Add(subDirectoryData);
                directorySizeBytes += DirectorySize(sortDirection, di, subDirectoryData);
            }
            directoryData.SizeBytes = directorySizeBytes;
            return directorySizeBytes;
        }
    }
