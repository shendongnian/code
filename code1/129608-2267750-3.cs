    dt.TableName = "Declaration"; 
 
    MemoryStream stream = new MemoryStream(); 
    dt.WriteXml(stream); 
    stream.Seek(0,SeekOrigin.Begin);   // <-- must do this after writing the stream!
 
    using (ZipFile zipFile = new ZipFile())
    {
      zipFile.AddEntry("Report.xml", "", stream); 
      Response.ClearContent(); 
      Response.ClearHeaders(); 
      Response.AppendHeader("content-disposition", "attachment; filename=Report.zip"); 
 
      zipFile.Save(Response.OutputStream); 
    }
