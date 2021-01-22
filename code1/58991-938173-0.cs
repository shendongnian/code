    MailMessage mailMessage = new MailMessage("me@me.com"
        ,"me@me.com"
        ,"test"
        ,"");
    string ContentId = "wecandoit.jpg";
    mailMessage.Body = "<img src=\"cid:" + ContentId + "\"/>";
    AlternateView av = AlternateView.CreateAlternateViewFromString(mailMessage.Body
        ,null
        ,MediaTypeNames.Text.Html);
    LinkedResource lr = new LinkedResource(@"d:\Personal\My Pictures\wecandoit.jpg");
    lr.ContentId = ContentId;
    lr.ContentType.Name = ContentId;
    lr.ContentType.MediaType = "image/jpeg";
    av.LinkedResources.Add(lr);
    mailMessage.AlternateViews.Add(av);
    SmtpClient cl = new SmtpClient();
    cl.PickupDirectoryLocation = @"c:\test";
    cl.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
    cl.Send(mailMessage);
