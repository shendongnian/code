    // using System.Net.Mail;
    SmtpClient client = new SmtpClient();
    MailMessage mm = new MailMessage()
    {
        Subject = "Subject here",
        Body = "Body here"
    };
    mm.To.Add("email@tempuri.org");
    client.Send(mm);
