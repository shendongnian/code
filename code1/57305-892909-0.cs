    var mailMessage = new MailMessage();
    Attachment data = new Attachment(attachment, contentType); 
    ContentDisposition disposition = data.ContentDisposition;
    disposition.FileName = "message.csv";
    mailMessage.Attachments.Add(data);
