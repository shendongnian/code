    string[] files = Directory.GetFiles(path);
    foreach (string file in files)
     {
      if (File.GetLastWriteTime(file) < DateTime.Now.AddDays(-5))
        {
          File.Delete(file);
        }
     }
            
