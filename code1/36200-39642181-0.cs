    // Execute the invoice page and get the HTML string rendered by this page
    TextWriter outTextWriter = new StringWriter();
    Server.Execute("Invoice.aspx", outTextWriter);
    
    string htmlStringToConvert = outTextWriter.ToString();
    
    // Create a HTML to PDF converter object with default settings
    HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
    
    // Use the current page URL as base URL
    string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri;
    
    // Convert the page HTML string to a PDF document in a memory buffer
    byte[] outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlStringToConvert, baseUrl);
    
    // Send the PDF as response to browser
    
    // Set response content type
    Response.AddHeader("Content-Type", "application/pdf");
    
    // Instruct the browser to open the PDF file as an attachment or inline
    Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Convert_Page_in_Same_Session.pdf; size={0}", outPdfBuffer.Length.ToString()));
    
    // Write the PDF document buffer to HTTP response
    Response.BinaryWrite(outPdfBuffer);
    
    // End the HTTP response and stop the current page processing
    Response.End();
