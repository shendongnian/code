    public IActionResult DownloadCertificate(int id)
    {
        var model = getData(id);
        return new ViewAsPdf("PdfCertificate", model)
        {
             FileName = "Cert.pdf"
        };
    }
