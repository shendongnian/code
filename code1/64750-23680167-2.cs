    // code to Send Mail 
    // Add following Lines in your web.config file 
    //               <system.net>
    //                  <mailSettings>
    //                    <smtp>
    //                        <network host="smtp.gmail.com" port="587" userName="xxx@gmail.com" password="yyy"   defaultCredentials="false"/>
    //                    </smtp>
    //               </mailSettings>
    //               </system.net>
    // Add below lines in your config file inside appsetting tag <appsetting></appsetting>
    //          <add key="emailFromAddress" value="xxxx@gmail.com"/>
    //       <add key="emailToAddress" value="xxxxxxx@gmail.com"/>
    //        <add key="EmailSsl" value="true"/>
         public static bool SendingMail(string subject, string content)
        {
           // getting the values from config file through c#
            string fromEmail = ConfigurationSettings.AppSettings["emailFromAddress"];
            string mailid = ConfigurationSettings.AppSettings["emailToAddress"];
            bool useSSL;
            if (ConfigurationSettings.AppSettings["EmailSsl"] == "true")
            {
                useSSL = true;
            }
            else
            {
                useSSL = false;
            }
                     
            SmtpClient emailClient;
            MailMessage message;
            message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.ReplyTo = new MailAddress(fromEmail);
            if (SetMailAddressCollection(message.To, mailid))
            {
                message.Subject = subject;
                message.Body = content;
                message.IsBodyHtml = true;
                emailClient = new SmtpClient();
                emailClient.EnableSsl = useSSL;
                emailClient.Send(message);
            }
            return true;
        }
        // if you are sending mail in group
        private static bool SetMailAddressCollection(MailAddressCollection toAddresses, string    mailId)
        {
            bool successfulAddressCreation = true;
            toAddresses.Add(new MailAddress(mailId));
            return successfulAddressCreation;
        }
