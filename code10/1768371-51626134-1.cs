    public static bool SendMail(string to,string subject, string body)
    {
    	try
    	{
    		MailMessage mailMessage = new MailMessage();
    		mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["smtpUser"]);
    		mailMessage.To.Add(new MailAddress(to));
    		mailMessage.Subject = subject;
    		mailMessage.IsBodyHtml = true;
    		mailMessage.Body = body;
    		using (SmtpClient smtp = new SmtpClient())
    		{
    			smtp.EnableSsl = true;
    			smtp.Host = ConfigurationManager.AppSettings["smtpServer"];
    			smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
    			smtp.UseDefaultCredentials = false;
    			smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"]);
    			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    			smtp.Send(mailMessage);
    			return true;
    		}
    	}
    	catch (Exception ex)
    	{
    		return false;
    	}
    }
