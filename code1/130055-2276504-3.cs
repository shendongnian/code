    try
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("abc@example.com");
        mailMessage.To.Add(new MailAddress("contact@example.com"));
        mailMessage.ReplyTo = new MailAddress(txtEmailId.Text);
        mailMessage.Subject = txtSubject.Text;
        mailMessage.Body = txtMessage.Text;
        mailMessage.IsBodyHtml = false;
        mailMessage.Priority = MailPriority.High;
        SmtpClient sc = new SmtpClient("relay-hosting.secureserver.net");
        //sc.Credentials = new System.Net.NetworkCredential("contact@example.com", "MyPassword");
        //send to only the contact@example.com first
        sc.Send(mailMessage);
        mailMessage.To.Clear();
        mailMessage.To.Add(new MailAddress(txtEmailId.Text));
        //add a simple message to the user at the beginning of the body
        mailMessage.Body = "Thank you for submitting your question. The following has been submitted to contact@example.com: <br/><br/>" + mailMessage.Body;
        //send the acknowledgment message to the user
        sc.Send(mailMessage);
 
    }
    catch (Exception ex)
    {
        Label1.Text = "An Error has occured : "+ex.Message;
    }
