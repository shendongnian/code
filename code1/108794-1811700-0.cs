    Response.Clear();
    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
    Response.AddHeader("Content-Length", targetFile.Length.ToString);
    Response.ContentType = "application/pdf";
    Response.WriteFile(targetFile.FullName); 
