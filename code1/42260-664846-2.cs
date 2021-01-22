    public static void ProcessFile(string filePath, Action<File> fileProcessor)
    {
      File openFile = null;
      try
      {
        openFile = File.Open(filePath); // I'm making this up ... point is you are acquiring a resource that needs to be cleaned up after.
        fileProcessor(openFile); 
      }
      finally
      {
        openFile.Close(); // Or dispose, or whatever.
      }
    }
