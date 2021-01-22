    public static bool Send(string receiverEmail, string ReceiverName, string subject, string body)
    {
            MailMessage mailMessage = new MailMessage();
            MailAddress mailAddress = new MailAddress("abc@gmail.com", "Sender Name"); // abc@gmail.com = input Sender Email Address 
            mailMessage.From = mailAddress;
            mailAddress = new MailAddress(receiverEmail, ReceiverName);
            mailMessage.To.Add(mailAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            SmtpClient mailSender = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("abc@gmail.com", "pass")   // abc@gmail.com = input sender email address  
                                                                               //pass = sender email password
            };
            try
            {
                mailSender.Send(mailMessage);
                return true;
            }
            catch (SmtpFailedRecipientException ex)
            { 
              // Write the exception to a Log file.
            }
            catch (SmtpException ex)
            { 
               // Write the exception to a Log file.
            }
            finally
            {
                mailSender = null;
                mailMessage.Dispose();
            }
            return false;
    }
