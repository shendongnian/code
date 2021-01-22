    using System.Net.Mail;
    var fromAddress = new MailAddress("from@gmail.com", "From Name");
    var toAddress = new MailAddress("to@example.com", "To Name");
    const string fromPassword = "fromPassword";
    const string subject = "Subject";
    const string body = "Body";
    var smtp = new SmtpClient
               {
                   Host = "smtp.gmail.com",
                   Port = 587,
                   EnableSsl = true,
                   DeliveryMethod = SmtpDeliveryMethod.Network,
                   UseDefaultCredentials = false,
                   Credentials = new NetworkCredential(fromAddress.ToString(), fromPassword)
               };
    using (var message = new MailMessage(fromAddress, toAddress)
                         {
                             Subject = subject,
                             Body = body
                         })
    {
        smtp.Send(message);
    }
