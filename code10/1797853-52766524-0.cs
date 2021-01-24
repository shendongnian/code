    static string Scan(string path)
        {
            try{
                   foreach (var file in Directory.EnumerateFiles(path, "zfsdfsdfsb.txt")){
                      Console.WriteLine("FILE: " + file);   
                      return file;
                   }
    
                  foreach (var dir in Directory.EnumerateDirectories(path)){
                      Console.WriteLine("DIRECTORY: " + dir);
                      var ret = Scan(dir);
                      if(ret != null)
                          return ret;
                   }
               }
             return null;
        }
