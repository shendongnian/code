    using (ZipArchive archive = ZipFile.OpenRead("archieve.zip")) 
    {
    
       foreach (ZipArchiveEntry entry in archive.Entries) 
       {
          using (Stream stream = entry.Open()) 
          {
             byte[] bytes;
             using (var ms = new MemoryStream()) 
             {
                stream.CopyTo(ms);
                bytes = ms.ToArray();
             }
          }
       }
    }
