    public HttpResponseMessage CreateLieferschein() {
      // Create the itext pdf
      MemoryStream stream = new MemoryStream();            
      PdfWriter writer    = new PdfWriter(stream);
      var pdf             = new PdfDocument(writer);
      var document        = new Document(pdf);
      document.Add(new Paragraph("Hello World!"));
      document.Close();  // don't forget to close or the doc will be corrupt! ;)
      // Load the mem stream into a StreamContent
      HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
      {
        Content = new StreamContent(stream)
      };
      
      // Prep the response with headers, filenames, etc.
      httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
      {
        FileName = "WebApi2GeneratedFile.pdf"
      };
      
      httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
         
      ResponseMessageResult responseMessageResult = ResponseMessage(httpResponseMessage);
      
      // Cross your fingers...
      return responseMessageResult;
        
    }
