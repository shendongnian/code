    HttpContext.Current.Response.Buffer = True
    HttpContext.Current.Response.ClearContent()
    HttpContext.Current.Response.ClearHeaders()
    HttpContext.Current.Response.ContentType = "application/pdf"
    HttpContext.Current.Response.TransmitFile(PDFFileName)
    HttpContext.Current.Response.Flush()
    HttpContext.Current.Response.Close()
    File.Delete(PDFFileName)
