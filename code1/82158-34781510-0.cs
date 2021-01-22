    private void SendMail()
        {
        string filename = Server.MapPath("~/MailTemplate.html");
        string username = UserName.Text.ToString();
        
        string mailbody = System.IO.File.ReadAllText(filename);
        mailbody = mailbody.Replace("##NAME##", username);
        string to = Email.Text;
        string from = "test@gmail.com";
        
        MailMessage message = new MailMessage(from, to);
        message.Subject = "Auto Response Email";
        message.Body = mailbody;
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("test@gmail.com", "test123#");
        client.EnableSsl = true;
        client.UseDefaultCredentials = true;
        client.Credentials = basicCredential;
        try
        {
            client.Send(message);
            SuccessMessage.Text = "Email Sending successfully";
        
        }
        catch (Exception ex)
        {
        
            ErrorMessage.Text = ex.Message.ToString();
        }
    }
