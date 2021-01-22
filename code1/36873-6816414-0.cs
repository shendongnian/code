    private string GetTempFile(string fileExtension)
    {
      string temp = System.IO.Path.GetTempPath();
      string res = string.Empty;
      while (true) {
        res = string.Format("{0}.{1}", Guid.NewGuid().ToString(), fileExtension);
        res = System.IO.Path.Combine(temp, res);
        if (!System.IO.File.Exists(res)) {
          try {
            System.IO.FileStream s = System.IO.File.Create(res);
            s.Close();
            break;
          }
          catch (Exception) {
          }
        }
      }
      return res;
    } // GetTempFile
