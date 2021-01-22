    public static void SendMail()
    {    
        var mailMessage = new MimeMailMessage();
        mailMessage.Subject = "test mail";
        mailMessage.Body = "hi dude!";
        mailMessage.Sender = new MimeMailAddress("you@gmail.com", "your name");
        mailMessage.To.Add(new MimeMailAddress("yourfriend@gmail.com", "your friendd's name")); 
    // You can add CC and BCC list using the same way
        mailMessage.Attachments.Add(new MimeAttachment("your file address"));
    //Mail Sender (Smtp Client)
        var emailer = new SmtpSocketClient();
        emailer.Host = "your mail server address";
        emailer.Port = 465;
        emailer.SslType = SslMode.Ssl;
        emailer.User = "mail sever user name";
        emailer.Password = "mail sever password" ;
        emailer.AuthenticationMode = AuthenticationType.Base64;
        // The authentication types depends on your server, it can be plain, base 64 or none. 
    //if you do not need user name and password means you are using default credentials 
    // In this case, your authentication type is none            
        emailer.MailMessage = mailMessage;
        emailer.OnMailSent += new SendCompletedEventHandler(OnMailSent);
        emailer.SendMessageAsync();
    }
    // A simple call back function:
    private void OnMailSent(object sender, AsyncCompletedEventArgs asynccompletedeventargs)
    {
    if (e.UserState!=null)
        Console.Out.WriteLine(e.UserState.ToString());
    if (e.Error != null)
    {
        MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if (!e.Cancelled)
    {
        MessageBox.Show("Send successfull!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    } 
