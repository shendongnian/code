            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(textFrom.Text);
                message.To.Add(textTo.Text);
                message.Subject = textSubject.Text;
                message.Body = textBody.Text;
                SmtpClient client = new SmtpClient();
                
                client.Host = textHost.Text;
                client.Port = Int32.Parse(textPort.Text);
                client.Credentials = new NetworkCredential(textUsername.Text, textPassword.Text);
                client.Send(message);
 
