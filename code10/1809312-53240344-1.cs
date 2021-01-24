     HashSet<string> openedFiles = new HashSet<string>();
     public static bool TryFirstRead(
         string path,
         out string result)
     {
         if (openedFiles.Add(path))
         {
              result = File.ReadAllText(path);
              return true;
         }
         result = null;
         return false;
     }
