            string From = "[MyGodaddyEMailAddress]"; //eg.info@mango.com
            string FromPassword = "[MyGodaddyMailPassword]";
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(From);
                msg.To.Add("[RecipientEmailAddress]");
                msg.Subject = "[MailSubject]";
                msg.Body = "[MailBody]";
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("mail.[domain].com", 587); //eg. mail.mango.com
                smtp.Credentials = new System.Net.NetworkCredential(From, FromPassword);
                smtp.EnableSsl = false;
                // Sending the email
                smtp.Send(msg);
                // destroy the message after sent
                msg.Dispose();
                Console.WriteLine("Message Sent Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
