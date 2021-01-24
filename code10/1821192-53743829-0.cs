        // List<FileInfo> Files = new List<FileInfo>();
        // client is created outside this method
        private void GetAttachmentsFromParts(IList<MessagePart> parts, string messageId)
        {
            if (parts == null) return;
                
            foreach (MessagePart part in parts)
            {
                if (!String.IsNullOrEmpty(part.Filename))
                {
                    String attId = part.Body?.AttachmentId ?? null;
                    if(String.IsNullOrWhiteSpace(attId)) continue;
                    
                    MessagePartBody attachPart = GmailServiceClient.Users.Messages.Attachments.Get("me", messageId, attId).Execute();
                    // Converting from RFC 4648 base64 to base64url encoding
                    // see http://en.wikipedia.org/wiki/Base64#Implementations_and_history
                    String attachData = attachPart.Data.Replace('-', '+');
                    attachData = attachData.Replace('_', '/');
                    byte[] data = Convert.FromBase64String(attachData);
                    var file = new FileInfo(part.Filename);
                    Files.Add(file);
                    File.WriteAllBytes(file.FullName, data);
                }
                 
                if((part.Parts?.Count ?? 0) > 0)
                    GetAttachmentsFromParts(part.Parts, messageId);
            }
        }
