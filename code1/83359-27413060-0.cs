    MailMessage msg = new MailMessage();
    AlternateView plainView = AlternateView
         .CreateAlternateViewFromString("Some plaintext", Encoding.UTF8, "text/plain");
    // We have something to show in real old mail clients.
    msg.AlternateViews.Add(plainView); 
    string htmlText = "The <b>fancy</b> part.";
    AlternateView htmlView = 
         AlternateView.CreateAlternateViewFromString(htmlText, Encoding.UTF8, "text/html");
    msg.AlternateViews.Add(htmlView); // And a html attachment to make sure.
    msg.Body = htmlText;  // But the basis is the html body
    msg.IsBodyHtml = true; // But the basis is the html body
