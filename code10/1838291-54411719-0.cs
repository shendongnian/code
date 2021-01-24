    var fileText = string.Empty;
    
     using (var file = File.OpenRead(System.Configuration.ConfigurationManager.AppSettings["zipPath"]))
        using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
        {
            using (var stream = zip.Entries.First().Open())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    try
                    {
                        while (!streamReader.EndOfStream)
                       {
                           var line = streamReader.ReadLine();
                           fileText = fileText + line;
                        }
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex);
                     }
                 }
             }
         }
