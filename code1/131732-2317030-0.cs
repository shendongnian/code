        string attachmentPath = Environment.CurrentDirectory + @"\test.png";
        Attachment inline = new Attachment(attachmentPath);
        inline.ContentDisposition.Inline = true;
        inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
        inline.ContentId = contentID;
        inline.ContentType.MediaType = "image/png";
        inline.ContentType.Name = Path.GetFileName(attachmentPath);
        message.Attachments.Add(inline);
