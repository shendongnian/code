    MailMessage message = new MailMessage();
    message.From = new MailAddress(fromEmailAddress);
    message.To.Add(toEmailAddress);
    message.Subject = "Test Email";
    message.Body = "body text\nblah\nblah";
    
    string html = "<body><h1>html email</h1><img src=\"cid:Pic1\" /><hr />" + message.Body.Replace(Environment.NewLine, "<br />") + "</body>";
    AlternateView alternate = AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html);
    message.AlternateViews.Add(alternate);
    
    Assembly assembly = Assembly.GetExecutingAssembly();
    using (Stream stream = assembly.GetManifestResourceStream("SendEmailWithEmbeddedImage.myimage.gif")) {
        LinkedResource picture = new LinkedResource(stream, MediaTypeNames.Image.Gif);
    
        picture.ContentId = "pic1"; // a unique ID 
        alternate.LinkedResources.Add(picture);
    
        SmtpClient s = new SmtpClient();
        s.Host = emailHost;
        s.Port = emailPort;
        s.Credentials = new NetworkCredential(emailUser, emailPassword);
        s.UseDefaultCredentials = false;
    
        s.Send(message);
    }
    }
