    HtmlToPdf htmlToPdfConverter = new HtmlToPdf();
    // set PDF page size, orientation and margins
    htmlToPdfConverter.Document.PageSize = PdfPageSize.A4;
    htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Portrait;
    htmlToPdfConverter.Document.Margins = new PdfMargins(0);
    // convert HTML to PDF 
    byte[] pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(url);
