    //Skipping the other code before this in the method.
    msg.Subject = ObjEmailDtl.Subject;
            msg.IsBodyHtml = true;
            msg.Body = ObjEmailDtl.Body;
    foreach(var attachment in ObjEmailDtl.Attachments)
    {
        Attachment att = new Attachment(new MemoryStream(attachment.Content), attachment.Name);
                msg.Attachments.Add(att);      
    }
    // Other code in the method.
