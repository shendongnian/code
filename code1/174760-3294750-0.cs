    MemoryStream ms = new MemoryStream(stream.FileContents); 
    // Create an in-memory System.IO.Stream
    
    ContentType ct = new ContentType(stream.ContentType);
    Attachement a = new Attachment(ms, ct);
