    using System.Threading;
    using System.Net.Mail;
    var sendMailThread = new Thread(() => {
        var message=new MailMessage();
        message.From="from e-mail";
        message.To="to e-mail";
        message.Subject="Message Subject";
        message.Body="Message Body";
        
        SmtpMail.SmtpServer="SMTP Server Address";
        SmtpMail.Send(message);
    });
    sendMailThread.Start();
