      public void RecursiveDelete(string path, string name)
      {
         foreach (string directory in Directory.GetDirectories(path))
         {
            if (directory.EndsWith("\\" + name))
            {
               Directory.Delete(directory, true);
            }
            else
            {
               RecursiveDelete(directory, name);
            }
         }
      }
