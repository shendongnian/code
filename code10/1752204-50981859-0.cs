    protected void btnDownloadExcelTemp_Click(object sender, EventArgs e)
    {
        try
        {
            string strFileFormat = System.Configuration.ConfigurationManager.AppSettings["FormateFilePath"].ToString();
            string strFilePath = strFileFormat + "/CMP_TEMPLATES.xlsx";
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.AppendHeader("content-disposition", "attachment; filename=" + "CMP_TEMPLATES.xlsx");
            response.ContentType = "application/octet-stream";
            response.WriteFile(strFilePath);
            response.Flush();
            response.End();
        }
        catch (Exception)
        {            
            throw;
        }
    }
