    dt.TableName = "Declaration"; 
    Response.ClearContent(); 
    Response.ClearHeaders(); 
    Response.ContentType = "application/zip";
    Response.AppendHeader("content-disposition", "attachment; filename=Report.zip"); 
 
    using(Ionic.Zip.ZipFile zipFile = new Ionic.Zip.ZipFile())
    {
        zipFile.AddEntry("Report.xml", (name,stream) => dt.WriteXml(stream) );
        zipFile.Save(Response.OutputStream); 
    }
