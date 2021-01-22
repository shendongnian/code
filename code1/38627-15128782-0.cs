      public static void renameFolder(String sourcePath, String targetPath) {
         try
         {
            if (System.IO.Directory.Exists(targetPath))
               DeleteFileSystemInfo(new DirectoryInfo(targetPath));
            System.IO.Directory.Move(sourcePath, targetPath);
         }
         catch (Exception ex)
         {
            Console.WriteLine("renameFolder: " + sourcePath + " " + targetPath + " " + ex.Message);
            throw ex;
         }
      }
    
      private static void DeleteFileSystemInfo(FileSystemInfo fsi) {
         fsi.Attributes = FileAttributes.Normal;
         var di = fsi as DirectoryInfo;
    
         if (di != null)
         {
            foreach (var dirInfo in di.GetFileSystemInfos())
            {
               DeleteFileSystemInfo(dirInfo);
            }
         }
    
         fsi.Delete();
      }
