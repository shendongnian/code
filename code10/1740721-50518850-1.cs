    var service = new ExchangeService
    {
        TraceEnabled = true
    };
    
    service.AutodiscoverUrl(Resources.EmailUsername, RedirectionUrlValidationCallback);
    
    var email = new EmailMessage(service);
                    
    if (!string.IsNullOrWhiteSpace(recipients))
    {
        foreach (var recipient in recipients.Split(','))
        {
            email.ToRecipients.Add(recipient.Trim());
        }
    }
    
    email.Subject = subject;
    email.Body = new MessageBody(BodyType.HTML, body);
    
    if (attachmentName != null && attachment != null)
    {
        email.Attachments.AddFileAttachment(attachmentName, attachment);                        
    }
    
    var folderId = new FolderId(WellKnownFolderName.SentItems, Resources.EmailUsername);
    
    email.Save(folderId);
    email.From = Resources.EmailUsername;
    email.Send();
