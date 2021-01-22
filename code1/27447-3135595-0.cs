    string[] theCookies = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
    foreach (string currentFile in theCookies)
    {
       try
       {
          System.IO.File.Delete(currentFile);
       }
       catch (Exception ex)
       {
       }
    }
