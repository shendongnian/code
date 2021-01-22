csharp
    var contentDispositionHeader = new System.Net.Mime.ContentDisposition
    {
    	Inline = false,
    	FileName = Uri.EscapeUriString(Path.GetFileName(pathFile)).Normalize()
    };
    Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
    string mimeType = MimeMapping.GetMimeMapping(Server.MapPath(pathFile));
    return File(file, mimeType);
