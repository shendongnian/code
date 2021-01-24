    public static bool IsFileInUse(string filename)
    {
      bool locked = false;
      try
      {
        FileStream fs =
        File.Open(filename, FileMode.OpenOrCreate,
        FileAccess.ReadWrite, FileShare.None);
        fs.Close();
      }
      catch (IOException ex)
      {
        locked = true;
      } 
     return locked;
    }
