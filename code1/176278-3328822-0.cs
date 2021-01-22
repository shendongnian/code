    var info = new FileInfo(path);
    
    Response.Clear();
    
    Response.AppendHeader("Content-Disposition", String.Concat("attachment; filename=", info.Name));
    Response.AppendHeader("Content-Length", info.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
    Response.AppendHeader("Content-Transfer-Encoding", "binary");
    Response.ContentType = "text/csv";
    
    Response.WriteFile(info.FullName, true);
    Response.End();
