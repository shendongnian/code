    public FileResult GetHTMLPageAsPDF(long empID) {
        string htmlPagePath = "anypath...";
        // convert html page to pdf
        PageToPDF obj_PageToPDF = new PageToPDF();
        byte[] databytes = obj_PageToPDF.ConvertURLToPDF(htmlPagePath);
        //return resulted pdf document        
        var contentLength = databytes.Length;      
        Response.AppendHeader("Content-Length", contentLength.ToString());
        Response.AppendHeader("Content-Disposition", "inline; filename=" + empID + ".pdf");
           
        return File(databytes, "application/pdf;");
    }
