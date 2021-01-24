    public ActionResult Download(ReportPage currentPage, string id)
    {
        var token = RystadIdentity.Current.AuthenticatedUser.Token;
    
        try
        {
            DocumentRequestInput documentRequestInput = new DocumentRequestInput(int.Parse(id), 2);
            documentRequestInput.Add(token);
        }
        catch
        { }
    
        Report report = RystadGlobal.api.GetReport(token, int.Parse(id)).Result;
        string ext = Path.GetExtension(report.fileName);
        byte[] byteArray = RystadGlobal.api.DownloadReport(token, report.Id).Result;
    
        if (ext.ToLower() == ".pdf")
        {
            var name = RystadIdentity.Current.AuthenticatedUser.UserInfo.name;
            var company = RystadIdentity.Current.AuthenticatedUser.UserInfo.company;
    
            try
            {
                byteArray = PdfWatermarker.Watermark(byteArray, name, company);
            }
            catch (Exception ex)
            {
                //Ignore if failed and give the user the pdf anyway
            }
        }
    
        return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Octet, report.fileName);
    }
