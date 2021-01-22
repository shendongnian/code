    string emailMessage="a skjdhak kdkand"; 
    MailMessage mail = new MailMessage();
                        mail.To.Add(obj_Artist.EmailAddress);
                        mail.From = new MailAddress(EmailList[0].FromEmail, "Sentric Music - Rights Management");
                           mail.Subject = (EmailList[0].Subject);
    
                        if (EmailList[0].BCC1 != null && EmailList[0].BCC1 != string.Empty)
                        {
                            mail.Bcc.Add(EmailList[0].BCC1);
                        }
                        if (EmailList[0].BCC2 != null && EmailList[0].BCC2 != string.Empty)
                        {
                            mail.Bcc.Add(EmailList[0].BCC2);
                        }
                        if (EmailList[0].CC1 != null && EmailList[0].CC1 != string.Empty)
                        {
                            mail.CC.Add(EmailList[0].CC1);
                        }
                        if (EmailList[0].CC2 != null && EmailList[0].CC2 != string.Empty)
                        {
                            mail.CC.Add(EmailList[0].CC2);`enter code here`
                        }
    
                        
                        string Body = emailMessage;
    
    
                        mail.Body = Body;
                        mail.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                        mail.IsBodyHtml = true;
                        AlternateView plainView = AlternateView.CreateAlternateViewFromString
                        (System.Text.RegularExpressions.Regex.Replace(Body, @"<(.|\n)*?>", string.Empty), null, "text/plain");
                        System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(Body, null, "text/html");
                        mail.AlternateViews.Add(plainView);
                        mail.AlternateViews.Add(htmlView);
                        SmtpClient smtp = new SmtpClient();
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
