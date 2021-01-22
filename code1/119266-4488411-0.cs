    FileInfo newFile = new FileInfo(Server.MapPath(tmpFile));
    
    //create file, and save it
    //...
    
    string attachment = string.Format("attachment; filename={0}", fileName);
    Response.Clear();
    Response.AddHeader("content-disposition", attachment);
    Response.ContentType = fileType;
    Response.WriteFile(newFile.FullName);
    Response.Flush();
    newFile.Delete();
    Response.End();
