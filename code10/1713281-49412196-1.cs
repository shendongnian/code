    //Zip file
    using (MemoryStream ms = new MemoryStream())
    {
        using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
        {
            ZipArchiveEntry archiveEntry = archive.CreateEntry("tblAccount.csv");
            using (StreamWriter streamWriter = new StreamWriter(archiveEntry.Open()))
            {
            	streamWriter.Write(accountSB.ToString());
            }
    
            //Continue adding ZipArchiveEntry objects (files) as necessary...
        }
            
        ms.Flush();
        ms.Position = 0;
        ms.Seek(0, SeekOrigin.Begin);
            
        //Return file...
    }
    
