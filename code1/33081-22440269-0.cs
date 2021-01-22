    public void TheDownload(string path)
    {
      System.IO.FileInfo toDownload = new System.IO.FileInfo(HttpContext.Current.Server.MapPath(path));
 
      HttpContext.Current.Response.Clear();
      HttpContext.Current.Response.AddHeader("Content-Disposition",
                 "attachment; filename=" + toDownload.Name);
      HttpContext.Current.Response.AddHeader("Content-Length",
                 toDownload.Length.ToString());
      HttpContext.Current.Response.ContentType = "application/octet-stream";
      HttpContext.Current.Response.WriteFile(patch);
      HttpContext.Current.Response.End();
    } 
