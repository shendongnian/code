    MailMessage msg = new MailMessage(username, nu.email, subject, body);
    msg.BodyEncoding = Encoding.UTF8;
    msg.SubjectEncoding = Encoding.UTF8;
    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlContent);
    htmlView.ContentType = new System.Net.Mime.ContentType("text/html");
    msg.AlternateViews.Add(htmlView);
