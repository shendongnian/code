    EmailMessage message = EmailMessage.Bind(service, Id, new PropertySet(ItemSchema.Attachments));
    
        foreach (Attachment attachment in message.Attachments)
        {
                message.Attachments.Remove(attachment);
                break;
        }
        message.Update(ConflictResolutionMode.AlwaysOverwrite);
