	using (var client = new SmtpClient())
	{
		MailMessage newMail = new MailMessage();
		newMail.To.Add(new MailAddress("you@your.address"));
		newMail.Subject = "Test Subject";
		newMail.IsBodyHtml = true;
		var inlineLogo = new LinkedResource(Server.MapPath("~/Path/To/YourImage.png"), "image/png");
		inlineLogo.ContentId = Guid.NewGuid().ToString();
		
		string body = string.Format(@"
				<p>Lorum Ipsum Blah Blah</p>
				<img src=""cid:{0}"" />
				<p>Lorum Ipsum Blah Blah</p>
			", inlineLogo.ContentId);
		
		var view = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
		view.LinkedResources.Add(inlineLogo);
		newMail.AlternateViews.Add(view);
		
		client.Send(newMail);
	}
