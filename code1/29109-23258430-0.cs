    var m = new MailMessage();
    
    string iCal = @"BEGIN:VCALENDAR......END:VCALENDAR";
    
    using (var iCalView = AlternateView.CreateAlternateViewFromString(iCal, new System.Net.Mime.ContentType("text/calendar")))
    {
        m.AlternateViews.Add(iCalView);
    
        var c = new SmtpClient();
    
        // Send message
        c.Send(m);
    }
