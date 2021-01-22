    void sendEmail(string strFrom
                            , string strTo
                            , string strSubject
                            , string strBody)
       {
           MailMessage objMailMessage = new MailMessage();
           System.Net.NetworkCredential objSMTPUserInfo =
               new System.Net.NetworkCredential();
           SmtpClient objSmtpClient = new SmtpClient();
           try
           {
               objMailMessage.From = new MailAddress(strFrom);
               objMailMessage.To.Add(new MailAddress(strTo));
               objMailMessage.Subject = strSubject;
               objMailMessage.Body = strBody;
               objSmtpClient = new SmtpClient("172.0.0.1"); /// Server IP
               objSMTPUserInfo = new System.Net.NetworkCredential
               ("User name", "Password","Domain");
               objSmtpClient.Credentials = objSMTPUserInfo;
               objSmtpClient.UseDefaultCredentials = false;
               objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
               objSmtpClient.Send(objMailMessage);
           }
           catch (Exception ex)
           { throw ex; }
           finally
           {
               objMailMessage = null;
               objSMTPUserInfo = null;
               objSmtpClient = null;
           }
       }
