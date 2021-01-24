    public bool SendEmail(Dictionary<string, byte[]> linkedResources)
    {
     using (SmtpClient mailSender = new SmtpClient("SmtpHost", 22))
     {
    	MailMessage emailMessage = new MailMessage()
        {
            Subject = "Subject",
            SubjectEncoding = Encoding.ASCII,
            IsBodyHtml = true,
            Body = "Message",
            BodyEncoding = Encoding.ASCII,
            From = new MailAddress("Sender@domain.com")
        };
    	emailMessage.BodyEncoding = Encoding.ASCII;
    	emailMessage.IsBodyHtml = true;
    	AlternateView av = AlternateView.CreateAlternateViewFromString(emailMessage.Body, null, MediaTypeNames.Text.Html);
    
    	foreach (var item in linkedResources)
    	{
    		MemoryStream streamBitmap = new MemoryStream(item.Value);
    		var linkedResource = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
    		linkedResource.ContentId = item.Key;
    		av.LinkedResources.Add(linkedResource);
    	}
    	emailMessage.AlternateViews.Add(av);
    	mailSender.Send(emailMessage);
    
    	return true;
     }
    }
