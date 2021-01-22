    //include this                    
    using System.Net.Mail;
                         
    string fromAddress = "xyz@gmail.com";
    string mailPassword = "*****";  //mail id password from where mail will be sent.
    string messageBody = "Write the body of the message here.";
    
                      
           //create smtp connection
           SmtpClient client = new SmtpClient();
           client.Port = 587;//outgoing port for the mail.
           client.Host = "smtp.gmail.com";
           client.EnableSsl = true;
           client.Timeout = 10000;
           client.DeliveryMethod = SmtpDeliveryMethod.Network;
           client.UseDefaultCredentials = false;
           client.Credentials = new System.Net.NetworkCredential( 
                                fromAddress, mailPassword);
          //fill the mail form.
          var send_mail = new MailMessage();
          
          send_mail.IsBodyHtml = true;
          //address from where mail will be sent.
          send_mail.From = new MailAddress("from@gmail.com");
          //address to which mail will be sent.           
          send_mail.To.Add(new MailAddress("to@example.com");
          //subject of the mail.
          send_mail.Subject = "put any subject here";
        
          send_mail.Body = messageBody;
          client.Send(send_mail);
