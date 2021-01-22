    protected void DisplayDownloadDialog()
    {
        Response.Clear();
        Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", "filename.xml"));
        Response.ContentType = "application/octet-stream";
        Response.WriteFile("FilePath");
        Response.End();
    }
