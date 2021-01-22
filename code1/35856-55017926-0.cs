    string timeStampForPdfName = DateTime.Now.ToString("yyMMddHHmmssff");
        
    string serverPath = System.Web.Hosting.HostingEnvironment.MapPath("~/FolderName");
    string pdfSavePath = Path.Combine(@serverPath, "FileName" + timeStampForPdfName + ".FileExtension");
        
        
    //OpenHtmlToPdf Library used for Performing PDF Conversion
    var pdf = Pdf.From(HTML_String).Content();
        
    //FOr writing to file from a ByteArray
     File.WriteAllBytes(pdfSavePath, pdf.ToArray()); // Requires System.Linq
