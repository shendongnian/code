    using (ZipFile zip = new ZipFile(ZipPath))
    {
         foreach (ZipEntry e in zip)
         {
            string newPath = Path.Combine(FolderToExtractTo, e.FileName);
    
            if (e.IsDirectory)
            {
               Directory.CreateDirectory(newPath);
            }
            else
            {
              using (FileStream stream = new FileStream(newPath, FileMode.Create))
                 e.Extract(stream);
            }
         }
    }
