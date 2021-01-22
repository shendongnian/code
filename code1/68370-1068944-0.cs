    System.IO.FileInfo file = new System.IO.FileInfo(path);
    
    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
    Response.AddHeader("Content-Length", file.Length.ToString());
    Response.ContentType = "application/octet-stream";
    Response.WriteFile(file.FullName);
    Response.End();
