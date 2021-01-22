                MimeMessage mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress(senderName, sender@address.com));
                mailMessage.Sender = new MailboxAddress(senderName, sender@address.com);
                mailMessage.To.Add(new MailboxAddress(emailid, emailid));
                mailMessage.Subject = subject;
                mailMessage.ReplyTo.Add(new MailboxAddress(replyToAddress));
                mailMessage.Subject = subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = "Hello There";            
                try
                {
                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.Connect("HostName", "Port", MailKit.Security.SecureSocketOptions.None);
                        smtpClient.Authenticate("user@name.com", "password");
    
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Success");
                    }
                }
                catch (SmtpCommandException ex)
                {
                    Console.WriteLine(ex.ToString());              
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());                
                }
