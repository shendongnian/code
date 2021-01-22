    using System.IO;
    DirectoryInfo Folder = new DirectoryInfo(@"c:\blah");
    if (Folder.Exists) // else: Invalid folder!
    {
      FileInfo[] Files = Folder.GetFiles("*.xml");
    
      foreach (FileInfo f in Files)
      {
        DoSmething(f.FullName);
      }
    }
