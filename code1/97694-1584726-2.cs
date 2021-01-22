    using System.IO;
    DirectoryInfo folder = new DirectoryInfo(@"c:\blah");
    if (folder.Exists) // else: Invalid folder!
    {
      FileInfo[] files = folder.GetFiles("*.xml");
    
      foreach (FileInfo file in files)
      {
        DoSmething(file.FullName);
      }
    }
