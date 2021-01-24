	[HttpPost]
	[ValidateInput(false)]
	public ActionResult SendBulkEmail(EmailAddress ea, HttpPostedFileBase postedFile)
	{
		string senderEmail = System.Configuration.ConfigurationManager.AppSettings["senderEmail"].ToString();
		string senderPassword = System.Configuration.ConfigurationManager.AppSettings["senderPassword"].ToString();
		if (ModelState.IsValid)
		{
			SqlDataReader reader;
			using (SqlConnection cs = new SqlConnection(conn))
			{
				cs.Open();
				SqlCommand cmd = new SqlCommand("SELECT email_address FROM Newsletter", cs);
				ArrayList emailArray = new ArrayList();
				reader = cmd.ExecuteReader();
				myFunctions m = new myFunctions();
				var emailList = m.LoadEmails();
				var emails = new List<AllEmailAddresses>();
				while (reader.Read())
				{
					emails.Add(new AllEmailAddresses
					{
						EmailAddress = Convert.ToString(reader["email_address"])
					});
				}
				foreach (AllEmailAddresses email in emailList)
				{
					SmtpClient client = new SmtpClient("mail.chijiokechinedu.com", 25);
					client.Timeout = 100000;
					client.DeliveryMethod = SmtpDeliveryMethod.Network;
					client.UseDefaultCredentials = false;
					client.Credentials = new NetworkCredential(senderEmail, senderPassword);
					//MailMessage mailMessage = new MailMessage(senderEmail, email.EmailAddress, ea.EmailSubjest, ea.EmailBody);
					MailMessage mailMessage = new MailMessage();
					mailMessage.From = new MailAddress(senderEmail);
					mailMessage.To.Add(new MailAddress(email.EmailAddress));
					mailMessage.Subject = ea.EmailSubjest;
					mailMessage.Body = ea.EmailBody;
					mailMessage.IsBodyHtml = true;
					mailMessage.BodyEncoding = UTF8Encoding.UTF8;
					if (postedFile != null)
					{
						string fileName = Path.GetFileName(postedFile.FileName);
						mailMessage.Attachments.Add(new Attachment(postedFile.InputStream, fileName));
					}
					client.Send(mailMessage);
				}
				
				// ** redirect after sending all the emails
				return RedirectToAction("EmailSentSuccessfully", "Home");
			}
		}
		else
		{
			ModelState.AddModelError("", "email failed to send!");
		}
		return View(ea);
	}
