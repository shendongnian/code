    private void button1_Click(object sender, EventArgs e)
    {
        MailMessage mail = new MailMessage("from@domain.com", "to@domain.com", "subj", "body");
        SmtpClient client = new SmtpClient("SMTPHOST");
        mail.IsBodyHtml = true;
        client.SendCompleted += new
        SendCompletedEventHandler(SendCompletedCallback);
        client.SendAsync(mail,mail);//send the mail object itself as argument to callback
    }
    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            //Mail sending is cancelled
        }
        if (e.Error != null)
        {
            //There is an error,e.Error will contain the exception
        }
        else
        {
            //Do any other success processing
        }
        ((MailMessage)e.UserState).Dispose();//Dispose
    }
