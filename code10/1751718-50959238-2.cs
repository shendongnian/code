    private static string SearchFile(string directory, Func<string, bool> condition)
    {
       // get all files
       var files = Directory.GetFiles(directory);
    
       // check the file against what you want
       if (files.Any(condition.Invoke))
          return directory; // if its found return
       
       // get all dirs
       var dirs = Directory.GetDirectories(directory);
    
       // check each one
       foreach (var dir in dirs)
       {
          Console.WriteLine($"Searching {dir}");
    
          try
          {
             // recurse
             var result = SearchFile(dir, condition);
    
             // if its found return
             if (result != null)
                return result;
          }
          catch (Exception ex)
          {
             // log
             Console.WriteLine(ex.Message);
          }
       }
       // nothing found here bail
       return null;
    }
