    // To copy all the files in one directory to another directory.
    // Get the files in the source folder. (To recursively iterate through
    // all subfolders under the current directory, see
    // "How to: Iterate Through a Directory Tree.")
    // Note: Check for target path was performed previously
    //       in this code example.
    if (System.IO.Directory.Exists(sourcePath))
    {
      string[] files = System.IO.Directory.GetFiles(sourcePath);
      // Copy the files and overwrite destination files if they already exist.
      foreach (string s in files)
      {
        // Use static Path methods to extract only the file name from the path.
        fileName = System.IO.Path.GetFileName(s);
        destFile = System.IO.Path.Combine(targetPath, fileName);
        System.IO.File.Copy(s, destFile, true);
      }
    }
