    /// <summary>
    /// Operates just like GetFileSystemInfos except it is recursive, operates on more than
    /// one FileSystemInfo, ensures no paths are duplicateed, and includes the original
    /// items in the return.
    /// </summary>
    /// <param name="files">A collection of files and/or directories to expand.</param>
    /// <returns>A Dictionary of all file, directories, and subfiles and subdirectories of 
    /// those directories and subdirectories.  The key is the fullpath, and the value
    /// is the FileSystemInfo.</returns>
    public static Dictionary<string, FileSystemInfo> ExpandFileSystemInfos(FileSystemInfo[] files)
    {
      Dictionary<string, FileSystemInfo> resultingFiles = new Dictionary<string,FileSystemInfo>();
      //GetFileSystemInfosRecursively will expand everything, except it may contain duplicates
      foreach (FileSystemInfo file in GetFileSystemInfosRecursively(files))
      {//so we just go through adding them to the Dictionary
        if (!resultingFiles.ContainsKey(file.FullName))
        {
          resultingFiles.Add(file.FullName, file);
        }
      }
      return resultingFiles;
    }
    //helper method for ExpandFileSystemInfos
    private static List<FileSystemInfo> GetFileSystemInfosRecursively(FileSystemInfo[] files)
    {
      List<FileSystemInfo> resultingFiles = new List<FileSystemInfo>();
      foreach (FileSystemInfo file in files)
      {
        if (file is DirectoryInfo)
        {
          //get its sub items and pass to another function to process
          DirectoryInfo dir = (DirectoryInfo)file;
          
          //recursive call, passing in subdirectories and files of current directory.  
          //The result returned will be all subdirectories and files nested within the current
          //dir.  So we add them to our collection of results for each directory we encounter.
          resultingFiles.AddRange(GetFileSystemInfosRecursively(dir.GetFileSystemInfos()));          
        }
        //else do nothing, it is a file we already know about
      }
      //resultingFiles now contains all sub items
      //It does not include the directories and files in files however, so we add them as well
      resultingFiles.AddRange(files);
      return resultingFiles;
    }
