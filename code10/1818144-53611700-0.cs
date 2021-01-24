    foreach (var fileAttachment in fileAttachments)
    {
        var stream = new System.IO.MemoryStream(fileAttachment.Content);
        message.Attachments.AddFileAttachment(fileAttachment.Name, stream);
    }
