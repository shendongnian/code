        MailMessage email = new MailMessage();
        email.From = txtFrom.Text;
        email.To = txtToEmail.Text;
        email.Subject = txtMSubject.Text; 
        email.Body = txtBody.Text;
        SmtpClient mailClient = new SmtpClient();
        mailClient.Host = "smtp.emailAddress";
        mailClient.Port = 2525;
        mailClient.Send(email );
        email.Dispose();
        
        // After Disposing the email object you can call file delete
        if (filePath != "")
        {
          if (System.IO.File.Exists(filePath))
          {
            System.IO.File.Delete(filePath); 
          }
        }
