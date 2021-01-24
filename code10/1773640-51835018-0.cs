    public string send(string gmailid, string password, string toemail, string subject, string body, string attachment)
        {
            string msg = null;
            MailMessage mail = new MailMessage();
            mail.To.Add(toemail);
            mail.From = new MailAddress(gmailid);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(attachment));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential
                        (gmailid, password);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                msg = "Your Email has been sent!";
            }
            catch (Exception ex)
            {
                msg = "Your Email could not be sent.";
            }
            return msg;
        }
    }
