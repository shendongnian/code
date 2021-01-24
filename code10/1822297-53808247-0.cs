     public void Send(Inquiry inquiry)
        {
            SmtpClient smtpClient = new SmtpClient ("smtp.1and1.com",587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("mail@mywebsite.com", "mypassword");
           
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            //Setting From , To and CC
            mail.From = new MailAddress("mail@mywebsite.com", "myname");
            mail.To.Add(new MailAddress("mail@mywebsite.com"));
            mail.Subject = $"New inquiry from {inquiry.Name}";
            mail.Body = $"From: {inquiry.Name}\n" +
                $"Phone number: {inquiry.PhoneNumber} \n" +
                $"Message: {inquiry.Message}\n \n" +
                $"Recieved: {inquiry.Date}";
           mail.ReplyToList.Add(new MailAddress(inquiry.Email));
            smtpClient.Send(mail);
        }
