    using (SmtpClient client = new SmtpClient())
	{
		using (MailMessage mail = new MailMessage(from, to))
		{
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			client.Host = "smtpexch";
			client.Port = 25;
			using (var attachment = new Attachment(attachmentPath))
			{
				mail.Attachments.Add(attachment);
				mail.Subject = subject;
				mail.Body = message;
				client.Send(mail);
			}                        
		}                    
	}
