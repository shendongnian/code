	public static class MailExtension
	{
		// GetEmailCreditial(out strServer) gets credentials from an XML file
		public static void Send(this MailMessage email)
		{
			string strServer = String.Empty;
			NetworkCredential credentials = GetEmailCreditial(out strServer);
			SmtpClient client = new SmtpClient(strServer) { Credentials = credentials };
			client.Send(email);
		}
		public static void Send(this IEnumerable<MailMessage> emails)
		{
			string strServer = String.Empty;
			NetworkCredential credentials = GetEmailCreditial(out strServer);
			SmtpClient client = new SmtpClient(strServer) { Credentials = credentials };
			foreach (MailMessage email in emails)
				client.Send(email);
		}
    }
  
    // Example of use: 
    new MailMessage("info@myDomain.com","you@gmail.com","This is an important Subject", "Body goes here").Send();
    //Assume email1,email2,email3 are MailMessage objects
    new List<MailMessage>(){email1, email2, email}.Send();
