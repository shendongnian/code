    var responseContentType = response.Content.Headers.GetValues("Content-Type").FirstOrDefault();
    
    if (!ContentType.TryParse(responseContentType, out ContentType documentContentType))
    {
        return;
    }
    
    var stream = await response.Content.ReadAsStreamAsync();
    
    MimeEntity entity = MimeEntity.Load(documentContentType, stream);
    Multipart multipart = entity as Multipart;
    
    if (multipart == null)
    {
        throw new Exception("Unable to cast entity to Multipart");
    }
    
    foreach (MimePart part in multipart.OfType<MimePart> ())
    {
        string contentType = part.ContentType.MimeType;
        string contentId = part.ContentId;
        string objectId = part.Headers["Object-ID"];
    
        if (string.IsNullOrWhiteSpace(contentId) || string.IsNullOrWhiteSpace(objectId) || string.IsNullOrWhiteSpace(contentType))
        {
            continue;
        }
    
        var filename = string.Format("{0}_{1}{2}", contentId, objectId, MimeTypeMap.GetExtension(contentType));
    
        using (var output = File.Create (filename))
            part.Content.DecodeTo (output);
    }
