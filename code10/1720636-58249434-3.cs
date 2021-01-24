     protected void btnSendMail_Click(object sender, EventArgs e)
    {
     MailMessage msg = new MailMessage();
     // get the receiver email address from web.config
     msg.To.Add(ConfigurationManager.AppSettings["receiverEmail"]);
     
     // get sender email address path from web.config file
     var address = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
     string emailAddress = address.Network.UserName;
     string password = address.Network.Password;
     NetworkCredential credential = new NetworkCredential(emailAddress, password);
     msg.Subject = " Subject text here "
    }
      SmtpClient client = new SmtpClient();
      client.EnableSsl = true;  
      client.Send(msg);   // send the message
