      static void PrintDisposableTypesFromDirectory(DirectoryInfo dir, bool warn)
      {
         foreach (FileInfo file in dir.GetFiles("*.dll"))
         {
            try
            {
               PrintDisposableTypesFromFile(file.FullName);
            }
            catch (Exception ex)
            {
               if (warn)
               {
                  Console.Error.WriteLine(
                     String.Format(
                        "WARNING: Skipped {0}: {1}",
                        new object[] { file.FullName, ex.Message }));
               }
            }
         }
         // recurse
         foreach (DirectoryInfo subdir in dir.GetDirectories())
            PrintDisposableTypesFromDirectory(subdir, warn);
      }
