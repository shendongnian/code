    public void SendEmail(string address, string attatchment)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("FromEmail@gmail.com");
                mail.To.Add("ToEmail@gmail.com");
                mail.Subject = "Report";
                mail.Body = "Report";
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(attatchment));
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("FromEmail@gmail.com", "Password");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
