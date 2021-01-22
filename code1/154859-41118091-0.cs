       public void Send(string from, string password, string to, string Message, string subject, string host, int port, string file)
    {
    
    MailMessage email = new MailMessage();
    email.From = new MailAddress(from);
    email.To.Add(to);
    email.Subject = subject;
    email.Body = Message;
    SmtpClient smtp = new SmtpClient(host, port);
    smtp.UseDefaultCredentials = false;
    NetworkCredential nc = new NetworkCredential(from, password);
    smtp.Credentials = nc;
    smtp.EnableSsl = true;
    email.IsBodyHtml = true;
    email.Priority = MailPriority.Normal;
    email.BodyEncoding = Encoding.UTF8;
    
    if (file.Length > 0)
    {
    Attachment attachment;
    attachment = new Attachment(file);
    email.Attachments.Add(attachment);
    }
    
    // smtp.Send(email);
    smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
    string userstate = "sending ...";
    smtp.SendAsync(email, userstate);
    }
    
    private static void SendCompletedCallBack(object sender,AsyncCompletedEventArgs e) {
    string result = "";
    if (e.Cancelled)
    {
    
    MessageBox.Show(string.Format("{0} send canceled.", e.UserState),"Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
    }
    else if (e.Error != null)
    {
    MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else {
    MessageBox.Show("your message is sended", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    
    }
   
