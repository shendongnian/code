    MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64Attachment));
    ms.Position = 0; // important
    ContentType ct = new ContentType(MediaTypeNames.Image.Jpeg);
    Attachment attachment = new Attachment(ms, ct);
    // etc
