    HttpResponseMessage result = new HttpResponseMessage();
    try 
    {
        byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfLocation);
        result.StatusCode = HttpStatusCode.OK;
        result.Content = new ByteArrayContent(pdfBytes );
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "BuildingDetail.pdf" };
    
    } 
    catch (Exception e) 
    {
        result.StatusCode = HttpStatusCode.InternalServerError;
        result.ReasonPhrase = e.Message;// "Error occured while exporting csv file!";
    }          
                
