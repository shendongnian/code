    FileStream fileCopy;
    while(File.Exists(actualName) || Directory.Exists(acutalName))
    {
      actualName = baseName + " (" + (++index) + ")"; 
      try
      {
        fileCopy = new FileStream(actualName, FileMode.CreateNew);
      }
      catch (IOException)
      {
         if (!File.Exists(actualName))
         {
           throw;
         }
      }
    }
