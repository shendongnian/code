    var plainView = AlternateView.CreateAlternateViewFromString(msgBody, new ContentType("text/plain; charset=UTF-8"));
                           
    MyMessage.AlternateViews.Add(plainView);
    MyMessage.BodyEncoding = Encoding.UTF8;
    MyMessage.IsBodyHtml = true;
    MyMessage.Subject = subjectLine;
    MyMessage.Body = msgBody;
