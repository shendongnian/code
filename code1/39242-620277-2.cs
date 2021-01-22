    using System.Net.Mail;
    // Email content
    string HTMLTemplatePath = @"path";
    string TextTemplatePath = @"path";
    string HTMLBody = "";
    string TextBody = "";
    HTMLBody = File.ReadAllText(HTMLTemplatePath);
    TextBody = File.ReadAllText(TextTemplatePath);
    HTMLBody = HTMLBody.Replace(["[BODY]", content);
    TextBody = HTMLBody.Replace(["[BODY]", content);
    // Create email code
    MailMessage m = new MailMessage();
    m.From = new MailAddress("address@gmail.com", "display name");
    m.To.Add("address@gmail.com");
    m.Subject = "subject";
    AlternateView plain = AlternateView.CreateAlternateViewFromString(_EmailBody + text, new System.Net.Mime.ContentType("text/plain"));
    AlternateView html = AlternateView.CreateAlternateViewFromString(_EmailBody + body, new System.Net.Mime.ContentType("text/html"));
    mail.AlternateViews.Add(plain);
    mail.AlternateViews.Add(html);
    SmtpClient smtp = new SmtpClient("server");
    smtp.Send(m);
