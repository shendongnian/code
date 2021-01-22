    //send emails to all subscribers 
                foreach (string email in DailySubscription)
                {
                    MailMessage mail = new MailMessage(); mail.From = new MailAddress("123@mywebsite.com", "My Web Site");
                    mail.To.Add(new MailAddress(email.ToString()));
                    mail.Subject = "Today's Articles";
                    mail.IsBodyHtml = true;
                    mail.Body = strArticleHeading;
                    System.Net.Mail.SmtpClient SmtpMail = "IP Address";
                    SmtpMail.Send(mail); <-- this
                }
