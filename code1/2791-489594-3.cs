    using System.Net.Mail;
    using System.Net;
    var fromAddress = new MailAddress("from@gmail.com", "From Name");
    var toAddress = new MailAddress("to@yahoo.com", "To Name");
    const string fromPassword = "password";
    const string subject = "test";
    const string body = "Hey now!!";
    var smtp = new SmtpClient
    {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
        Timeout = 20000
    };
    using (var message = new MailMessage(fromAddress, toAddress)
    {
        Subject = subject,
        Body = body
    })
    {
        smtp.Send(message);
    }
