    if (context.Request.Headers[HEADER_RANGE] != null)
    {
      ...
    }
    else
    {
        context.Response.ContentType = contentItem.MimeType;
        addHeader(context.Response, HEADER_CONTENT_DISPOSITION, "attachment; filename=\"" + contentItem.Filename + "\"");
        addHeader(context.Response, HEADER_CONTENT_LENGTH, contentItem.FileBytes.Length.ToString());
        context.Response.OutputStream.Write(contentItem.FileBytes, 0, contentItem.FileBytes.Length);
    }
