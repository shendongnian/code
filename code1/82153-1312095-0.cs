    SmtpClient ss = new SmtpClient("smtp.gmail.com", 587);
    ss.EnableSsl = true;
    ss.Timeout = 10000;
    ss.DeliveryMethod = SmtpDeliveryMethod.Network;
    ss.UseDefaultCredentials = false;
    ss.Credentials = new NetworkCredential("username", "pass");
    
    MailMessage mm = new MailMessage("donotreply@domain.com", "destination@domain.com", "subject here", "my body");
    mm.BodyEncoding = UTF8Encoding.UTF8;
    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    ss.Send(mm);
