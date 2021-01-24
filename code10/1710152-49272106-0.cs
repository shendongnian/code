    Document document = new Document(PageSize.A4);
    MemoryStream ms = new MemoryStream();
    PdfWriter writer = PdfWriter.GetInstance(document, ms);
    document.Open();
    document.NewPage();
    ...
    ...
    document.Close();
    
    Response.Clear();
    Response.ContentType = "application/pdf";
    byte[] pdfBytes = ms.ToArray();
    Response.AppendHeader("Content-Length", pdfBytes.Length.ToString());
    Response.OutputStream.Write(pdfBytes, 0, (int)pdfBytes.Length);
