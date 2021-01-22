    Response.ContentType = "application/zip";
    Response.AddHeader("Content-Length", contentLength.ToString());
    Response.AddHeader("Content-disposition", "attachment; filename=" + fileName);
    if (Request.UserAgent.Contains("MSIE"))
    {
        Response.AddHeader("Content-Transfer-Encoding", "binary");
    }
