    string File = Server.MapPath(@"filename.doc");
    string FileName = "filename.doc";
    
    if (System.IO.File.Exists(FileName))
    {
    
        FileInfo fileInfo = new FileInfo(File);
        
        Response.Clear();
        Response.ContentType = "Application/msword";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
        Response.WriteFile(fileInfo.FullName);
        Response.End();
    }
