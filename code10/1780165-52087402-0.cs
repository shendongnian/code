    public static void SendToBrowser(string virtualPath)
    {
        string FilePath = HttpContext.Current.Server.MapPath(virtualPath);
        System.IO.FileInfo TargetFile = new System.IO.FileInfo(FilePath);
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + TargetFile.Name);
        HttpContext.Current.Response.AddHeader("Content-Length", TargetFile.Length.ToString());
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        HttpContext.Current.Response.WriteFile(TargetFile.FullName);
        HttpContext.Current.Response.End();
    }
 
