    string html = @"<html><body><img src=""cid:YourPictureId""></body></html>";
    AlternateView altView = AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html);
    LinkedResource yourPictureRes = new LinkedResource("yourPicture.jpg", MediaTypeNames.Image.Jpeg);
    yourPictureRes.ContentId = "YourPictureId";
    altView.LinkedResources.Add(yourPicture);
    MailMessage mail = new MailMessage();
    mail.AlternateViews.Add(altView);
