    private void CopyFile(string[] ListFilePaths)
    {
      System.Collections.Specialized.StringCollection FileCollection = new System.Collections.Specialized.StringCollection();
    
      foreach(string FileToCopy in ListFilePaths)
      {
        FileCollection.Add(FileToCopy);
      }
      Clipboard.SetFileDropList(FileCollection);
    }
