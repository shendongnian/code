    using (Attachment attachment = new Attachment(filename))
    {
        message.Attachments.Add(attachment);
        client.SendAsync(message, string.Empty);
    }
    File.Delete(filename);
