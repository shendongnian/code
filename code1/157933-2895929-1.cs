    static void Main(string[] args)
    {
       string directoryName = args[0];
       if(!Directory.Exists(directoryName))
       {
          Console.WriteLine("ERROR: Directory '{0}' does not exist!", directoryName);
          return;
       }
       using (testEntities entities = new testEntities())
       {
          StoredDir dir = new StoredDir{ DirName = directoryName };
          entities.AddToStoredDirSet(dir);
          foreach (string filename in Directory.GetFiles(directoryName))
          {
             StoredFile stFile = new StoredFile { FileName = Path.GetFileName(filename), Directory = dir };
             entities.AddToStoredFileSet(stFile);
          }
          try
          {
             entities.SaveChanges();
          }
          catch(Exception exc)
          {
             string message = exc.GetType().FullName + ": " + exc.Message;
          }
       }
    }
