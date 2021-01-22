    /// <summary>
    /// Compares the files to see if they are different. 
    /// First checks file size
    /// Then modified if the file is larger than the specified size
    /// Then compares the bytes
    /// </summary>
    /// <param name="file1">The source file</param>
    /// <param name="file2">The destination file</param>
    /// <param name="mb">Skip the smart check if the file is larger than this many megabytes. Default is 10.</param>
    /// <returns></returns>
    public static bool IsDifferentThan(this FileInfo file1, FileInfo file2, int mb = 10)
    {
      var ret = false;
      
      // different size is a different file
      if(file1.Length != file2.Length) return true;
      
      // if the file times are different and the file is bigger than 10mb flag it for updating
      if(file1.LastWriteTimeUtc > file2.LastWriteTimeUtc && file1.Length > ((mb*1024)*1024)) return true;
      var f1 = File.ReadAllBytes(file1.FullName);
      var f2 = File.ReadAllBytes(file2.FullName);
      // loop through backwards because if they are different
      // it is more likely that the last few bytes will be different
      // than the first few
      for(var i = file1.Length - 1; i > 0; i--)
      {
        if(f1[i] != f2[i])
        {
          ret = true;
          break;
        }
      }
      return ret;
    }
