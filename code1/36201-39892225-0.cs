    TextWriter outTextWriter = new StringWriter();
    Server.Execute("Invoice.aspx", outTextWriter);
    
    HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
    
    byte[] pdfBytes = htmlToPdfConverter.ConvertHtml(outTextWriter.ToString(),
                httpContext.Current.Request.Url.AbsoluteUri);
 
