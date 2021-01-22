        public void SendEmail()
        {
            MailMessage loMsg = new MailMessage();
            loMsg.From = new MailAddress("from@domain.com");
            loMsg.To.Add(new MailAddress("to@domain.com"));
            loMsg.Subject = "Subject";
            loMsg.Body = "Email Body";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("username", "password")
            };
            smtp.Send(loMsg);
            }
