    var attachment = new MimePart ("image", "gif") {
        Content = new MimeContent (File.OpenRead (path), ContentEncoding.Default),
        ContentDisposition = new ContentDisposition (ContentDisposition.Attachment),
        ContentTransferEncoding = ContentEncoding.Base64,
        FileName = Path.GetFileName (path)
    };
