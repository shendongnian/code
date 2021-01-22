    /// <summary>
    /// Scans a folder and all of its subfolders recursively, and updates the List of files
    /// </summary>
    /// <param name="sFullPath">Full path of the folder</param>
    /// <param name="files">The list, where the output is expected</param>
    internal static void EnumerateFiles(string sFullPath, List<FileInfo> fileInfoList)
    {
        try
        {
            DirectoryInfo di = new DirectoryInfo(sFullPath);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
                fileInfoList.Add(file);
            //Scan recursively
            DirectoryInfo[] dirs = di.GetDirectories();
            if (dirs == null || dirs.Length < 1)
                return;
            foreach (DirectoryInfo dir in dirs)
                EnumerateFiles(dir.FullName, fileInfoList);
        }
        catch (Exception ex)
        {
            Logger.Write("Exception in Helper.EnumerateFiles", ex);
        }
    }
}
