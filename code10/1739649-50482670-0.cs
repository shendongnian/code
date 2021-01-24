    Response.Clear(); 
    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); 
    Response.AddHeader("Content-Length", file.Length.ToString()); 
    Response.ContentType = "application/octet-stream"; 
    Response.WriteFile(file.FullName); 
    Response.End();
