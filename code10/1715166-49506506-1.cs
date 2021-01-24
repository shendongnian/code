    private static async Task<Attachment> GetUploadedAttachmentAsync(string serviceUrl, string conversationId)
    {
        var imagePath = System.Web.HttpContext.Current.Server.MapPath(@"~\csv_files\Results.csv");
    
        using (var connector = new ConnectorClient(new Uri(serviceUrl)))
        {
            var attachments = new Attachments(connector);
            var response = await attachments.Client.Conversations.UploadAttachmentAsync(
                conversationId,
                new AttachmentData
                {
                    Name = "Results.csv",
                    OriginalBase64 = File.ReadAllBytes(imagePath),
                    Type = "text/csv"
                });
    
            var attachmentUri = attachments.GetAttachmentUri(response.Id);
    
            return new Attachment
            {
                Name = "Results.csv",
                ContentType = "text/csv",
                ContentUrl = attachmentUri
            };
        }
    }
