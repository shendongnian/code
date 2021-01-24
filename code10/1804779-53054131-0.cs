    using (var stream = new FileStream(path, FileMode.Create))
    {
       using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
       {
         ZipArchiveEntry manifest = archive.CreateEntry(filenameManifest);
         using (Stream st = manifest.Open())
         {
             using (StreamWriter writerManifest = new StreamWriter(st))
             {
                writerManifest.WriteLine(JSONObject_String);
             }
         }
    
         ZipArchiveEntry pdfFile = archive.CreateEntry(filenameManifest);
         using (Stream st = manifest.Open())
         {
             using (StreamWriter writerPDF = new StreamWriter(st))
             {
                writerPDF.WriteLine(pdf);
             }
         }
       }
     }
