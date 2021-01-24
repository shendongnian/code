     bool IsAvailable(string path)
     {
          try
          {
               if (File.Exists(path))
                  using (File.OpenRead(path))
                  {
                      return true;
                  }
               else
                  return false;
           }
           catch (Exception)
           {
               Thread.Sleep(100);
               return InUse(path);
           }
     }
