    try
    {
    	using (MailMessage mail = new MailMessage())
    	{
    		mail.To.Add(toemail);
    		mail.To.Add(ccname);
    		mail.From = new MailAddress(from);
    		mail.Subject = "test email";
    		body = "<div> Hello, this is the body content of the email.</div>";
    		mail.Body = body;
    		mail.IsBodyHtml = true;
    		SmtpClient client = new SmtpClient("localhost");
    		client.Send(mail);
    	}
    }
    catch (Exception ex)
    {
    	Console.WriteLine("Exception caught in Creating test email {0}", ex.ToString());
    }   
