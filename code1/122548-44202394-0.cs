    public void sendUsersMail(string recipientMailId, string ccMailList, string body, string subject)
        {
            try
            {  
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("norepl@xyz.com", "Tracker Tool");
                Msg.To.Add(recipientMailId);
                if (ccMailList != "")
                    Msg.CC.Add(ccMailList);
                Msg.Subject = subject;
                var AltBody = AlternateView.CreateAlternateViewFromString(body, new System.Net.Mime.ContentType("text/html"));
                Msg.AlternateViews.Add(AltBody);
                Msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("mail.xyz.com");
                smtp.Send(Msg);
                smtp.Dispose();
            }
            catch (Exception ex)
            { 
            }
        }
