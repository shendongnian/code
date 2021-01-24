    public void DownloadWorkbook(string filePath)
    {
        FileInfo file = new FileInfo(filePath);
        HttpResponse response = System.Web.HttpContext.Current.Response;
    
        response.ClearContent();
    
        response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        response.AddHeader("Content-Length", file.Length.ToString());       
        response.ContentType = "text/csv";
        response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        response.TransmitFile(file.FullName);
        response.End();
    }
