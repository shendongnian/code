    var msg = new MailMessage(fromAddress, toAddress)
    {
      Subject = "attachment test", 
      IsBodyHtml = true, 
      Body = "this is the body"
    };
    
    var attachment = new Attachment(attachmentPath);
    msg.Attachments.Add(attachment);
    
    using (var client = new SmtpClient("smtp.sendgrid.net"))
    {
      client.UseDefaultCredentials = false;
      client.EnableSsl = true;
      client.Port = 587;
      client.Credentials = new NetworkCredential("key","password");
    
      await client.SendMailAsync(msg);
    }
