    if (attachmentFilename != null)
    {
        Attachment attachment = new Attachment(attachmentFilename, MediaTypeNames.Application.Octet);
        ContentDisposition disposition = attachment.ContentDisposition;
        disposition.CreationDate = File.GetCreationTime(attachmentFilename);
        disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
        disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
        disposition.FileName = Path.GetFileName(attachmentFilename);
        disposition.Size = new FileInfo(attachmentFilename).Length;
        disposition.DispositionType = DispositionTypeNames.Attachment;
        message.Attachments.Add(attachment);                
    }
