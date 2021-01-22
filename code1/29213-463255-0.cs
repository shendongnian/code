    MailMessage mail = new MailMessage() {
        To = "someone@somewhere",
        From = "someone@somewhere",
        Subject = "My Subject",
        Body = "My message"
    };
    SmtpClient client = new SmtpClient("SMTP Server Address");
    client.Send(mail);
