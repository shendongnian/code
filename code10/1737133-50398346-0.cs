    private List<String> Get_Messages()
    {
        List<String> list = new List<string>();
        list.Add("Hello");
        list.Add("Hello 2");
    
        return list;
    
    }
    
    private void SendEmail()
    {
    
        foreach (String messages in Get_Messages())
        {
            //prepare email. 
            String subject = "test email message";
    
            String emailFrom = "emailFrom@email.com"
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
    
            client.Port = 25;
            client.Host = "yourhost.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("username", "password");
    
    
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            objeto_mail.From = new MailAddress(emailFrom);
    
            objeto_mail.To.Add(new MailAddress("emailto@emailto.com"));
    
            objeto_mail.IsBodyHtml = true;
            objeto_mail.Subject = subject;
            objeto_mail.Body = messages;
            client.Send(objeto_mail);
            client.Dispose();
        }
    
    
    }
