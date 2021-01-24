    SmtpClient client = new SmtpClient("smtp.live.com", 587);
    client.EnableSsl = true;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.UseDefaultCredentials = false;
    client.Credentials = new NetworkCredential("xxxxx@hotmail.com", "******");
    MailMessage msgobj = new MailMessage();
    msgobj.To.Add(obj.ToEmail);
    msgobj.From = new MailAddress("xxxxx@hotmail.com");
    msgobj.Body = obj.EMailBody;
    msgobj.Subject = obj.EmailSubject;
    msgobj.CC.Add(obj.EmailCC);
    msgobj.Bcc.Add(obj.EmailBCC);
    
    if (obj.imageFile != null && obj.imageFile.ContentLength > 0)
    {
        msgobj.Attachments.Add(new Attachment(obj.imageFile.InputStream, obj.imageFile.FileName));
    }
    
    client.Send(msgobj);
