    protected void btnSubmit_Click(object sender, EventArgs e)
    {
         Mail.MailSent(); // increments every time you send mail
         // to check how many mails sent in debug console
         System.Diagnostics.Debug.WriteLine(Mail.GetMailCount()); 
         //... YOU MAILING CODE
    }
