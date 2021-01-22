    MemoryStream ms = new MemoryStream(fileContentResult.FileContents); 
    // Create an in-memory System.IO.Stream
    
    ContentType ct = new ContentType(fileContentResult.ContentType);
    Attachment a = new Attachment(ms, ct);
