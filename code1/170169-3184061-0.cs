     /// <summary>
    /// Transmit an email message
    /// </summary>
    /// <param name="from">Senders Name </param>
    /// <param name="fromPerson">Sender Email Address</param>
    /// <param name="body">The Email Message Body</param>
    /// <returns>Status Message as String</returns>
    public static void SendMail(string fromEmail, string fromName, string body)
    {
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.To.Add("abc@gmail.com");
                mail.From = new MailAddress(fromEmail, fromName);
                mail.Subject = "Report ";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = body;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = global::ProjectName.Properties.Settings.Default.Host;
                smtp.Port = global::ProjectName.Properties.Settings.Default.Port;
                if (smtp.Port == 587)
                {
                    smtp.EnableSsl = true;
                }
                string userName = global::ProjectName.Properties.Settings.Default.UserName;
                string password = global::ProjectName.Properties.Settings.Default.Password;
                smtp.Credentials = new NetworkCredential(userName, password);
                smtp.Send(mail);
            }
        }
        catch (SmtpException smEx)
        {
            LogError(smEx.Message, smEx.StackTrace);
        }
    }
