    using (var msg = new MailMessage())
            {
                msg.To.Add(new MailAddress(userName));
                msg.From = new MailAddress(userName);
                msg.ReplyToList.Add(model.EmailAddress);
                msg.Subject = "Message from the Web";
                msg.Body = sb.ToString();
                msg.IsBodyHtml = true;
                var client = new SmtpClient
                {
                    Host = "xxxmydomainxxx-co-uk.mail.protection.outlook.com",
                    Credentials = new System.Net.NetworkCredential(userName, password),
                    Port = 25,
                    EnableSsl = true
                };
                // You can use Port 25 if 587 is blocked 
                try
                {
                    client.Send(msg);
                    return true;
                }
                catch (SmtpException smtpEx)
                {
                    return smtpEx;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
