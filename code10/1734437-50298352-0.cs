        public async Task<bool> SendAsync(EmailMessage message)
        {
            bool result = true;
            try
            {
                using (var email = new MailMessage("from@gmail.com", "to@gmail.com", message.Subject, message.Body))
                {
                    var mailClient = new SmtpClient("smtp.gmail.com", 587) { Credentials = new NetworkCredential("from@gmail.com", "password"), EnableSsl = true };
                    await mailClient.SendMailAsync(email);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
    Hotmail settings
    Server	        Port
    smtp.live.com	25, 587
