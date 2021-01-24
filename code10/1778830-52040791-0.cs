    MailMessage mailWithImg = getMailWithImg();
    MySMTPClient.Send(mailWithImg); //* Set up your SMTPClient before!
    
    private MailMessage getMailWithImg() {
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        mail.AlternateViews.Add(getEmbeddedImage("c:/image.png"));
        mail.From = new MailAddress("yourAddress@yourDomain");
        mail.To.Add("recipient@hisDomain");
        mail.Subject = "yourSubject";
        return mail;
    }
    private AlternateView getEmbeddedImage(String filePath) {
        LinkedResource res = new LinkedResource(filePath);
        res.ContentId = Guid.NewGuid().ToString();
        string htmlBody = @"<img src='cid:" + res.ContentId + @"'/>";
        AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
        alternateView.LinkedResources.Add(res);
        return alternateView;
    }
