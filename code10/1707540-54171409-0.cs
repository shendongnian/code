    private static async Task SaveAttachments(Message message)
    {
        var attachments = 
            await _client.Me.MailFolders.Inbox.Messages[message.Id].Attachments.Request().GetAsync();
    
        foreach (var attachment in attachments.CurrentPage)
        {
            if (attachment.GetType() == typeof(FileAttachment))
            {
                var item = (FileAttachment)attachment; // Cast from Attachment
                var folder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var filePath = Path.Combine(folder, item.Name);
                System.IO.File.WriteAllBytes(filePath, item.ContentBytes);
            }
        }
    }
