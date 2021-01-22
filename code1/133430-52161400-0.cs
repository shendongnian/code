      private static void SendMail(string subject, string content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("YOURMAİL");
                mail.To.Add("MAİLTO");
                mail.Subject = subject;
                mail.Body = content;
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("YOURMAİL", "YOURMAİLPASSWORD");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }
