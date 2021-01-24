	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> SendEmailAsync(EmailFormModel model)
	{
		if (ModelState.IsValid)
		{
			// Create IDisposable inside `using` block so you aren't on the hook for calling Dispose()
			// The same has been done with your MailMessage
			using(SmtpClient client = new SmtpClient())
			{
				client.Credentials = new NetworkCredential("", "");
				client.Host = "smtp.gmail.com";
				client.Port = 587;
				client.EnableSsl = false;
				// You were missing this before which
				// was causing the exception. But due
				// to the thread your email was sent from
				// the exception was not thrown from a context
				// where you could know about it at all.
				await client.ConnectAsync();
				
				using(MailMessage message = new MailMessage())
				{
					var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
					message.To.Add(new MailAddress("stefan.cv5@gmail.com"));  // replace with valid value 
					message.From = new MailAddress("stefan.cv5@gmail.com");  // replace with valid value
					message.Subject = "Your email subject";
					message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
					message.IsBodyHtml = true;
					
					await client.SendAsync(message);
				}
			}
		}
		
		return View(model);
	}
