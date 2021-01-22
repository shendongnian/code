    dt.TableName = "Declaration"; 
    if (dt.Rows != null && dt.Rows.Count >= 1){
       using (MemoryStream stream = new MemoryStream()){
         dt.WriteXml(stream); 
 
         using (ZipFile zipFile = new ZipFile()){
          zipFile.AddEntry("Report.xml", "", stream); 
          Response.ClearContent(); 
          Response.ClearHeaders(); 
          Response.AppendHeader("content-disposition", "attachment; filename=Report.zip"); 
 
          zipFile.Save(Response.OutputStream); 
          Response.Write(zipstream); 
         }
       } 
    }
    // No rows...don't bother...
