    var streams = new List<Stream> ();
    if (attachments != null) {
        foreach (string attachmentPath in attachments) {
            // create an attachment for the file located at path
            var stream = File.OpenRead(attachmentPath);
            var attachment = new MimePart(MimeTypes.GetMimeType(attachmentPath)) {
                Content = new MimeContent(stream, ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(attachmentPath)
            };
            multipart.Add(attachment);
            streams.Add (stream);
        }
    }
