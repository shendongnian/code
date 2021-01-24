    public void DownloadZipFromMultipleFile()
    {
       using (var memoryStream = new MemoryStream())
       {
          using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
          {
             archive.CreateEntryFromFile(Server.MapPath("~/Content/appStyle.css"), "myStyle.css");
             archive.CreateEntryFromFile(Server.MapPath("~/NewPath/myScript.js"), "script.js");
          }
          byte[] bytesInStream = memoryStream.ToArray(); // simpler way of converting to array 
          memoryStream.Close(); 
          Response.Clear(); 
          Response.ContentType = "application/force-download"; 
          Response.AddHeader("content-disposition", "attachment; filename=name_you_file.zip"); 
          Response.BinaryWrite(bytesInStream); Response.End();
       }
    
       //archive.Save(Response.OutputStream);
    }
