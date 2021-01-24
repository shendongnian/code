     [HttpGet]
    public HttpResponseMessage CreateLieferschein()
    {
    
    	Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
    	byte[] buffer;
      HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
    	 using(MemoryStream stream = new MemoryStream())
    	 {
    	 using(PdfWriter wri = PdfWriter.GetInstance(doc, mem)) 
    	 {
    		   PdfWriter writer = new PdfWriter(stream);
    		var pdf = new PdfDocument(writer);
    		var document = new Document(pdf);
    		document.Add(new Paragraph("Hello World!"));
    	 }
    	 buffer = stream.ToArray();
    	   var contentLength = buffer.Length;
    	   
    	  var statuscode = HttpStatusCode.OK;
            response = Request.CreateResponse(statuscode);
            response.Content = new StreamContent(new MemoryStream(buffer));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = contentLength;
            ContentDispositionHeaderValue contentDisposition = null;
            if (ContentDispositionHeaderValue.TryParse("inline; filename=" + document.Name + ".pdf", out contentDisposition)) {
                response.Content.Headers.ContentDisposition = contentDisposition;
            }
        } else {
            var statuscode = HttpStatusCode.NotFound;
            var message = String.Format("Unable to find file. file \"{0}\" may not exist.", docid);
            var responseData = responseDataFactory.CreateWithOnlyMetadata(statuscode, message);
            response = Request.CreateResponse((HttpStatusCode)responseData.meta.code, responseData);
        }
    	
    	return response;
    
    	 }
