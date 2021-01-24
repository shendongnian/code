    public string send(string gmailid, string password, string toemail, string subject, string body)
        {
            string msg = null;
            MailMessage mail = new MailMessage();
            mail.To.Add(toemail);
            mail.From = new MailAddress(gmailid);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential
                        (gmailid, password);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                msg = "Your Message has been sent!";
            }
            catch (Exception)
            {
                msg = "Your Message could NOT be sent.";
            }
            return msg;
        }
