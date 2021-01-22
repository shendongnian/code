    FileInfo file = new FileInfo(filePath); // full file path on disk
    Response.ClearContent(); // neded to clear previous (if any) written content
    Response.AddHeader("Content-Disposition", 
        "attachment; filename=" + file.Name);
    Response.AddHeader("Content-Length", file.Length.ToString());
    Response.ContentType = "text/xml"; //RFC 3023
    Response.TransmitFile(file.FullName);
    Response.End();
