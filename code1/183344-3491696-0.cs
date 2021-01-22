    System.Net.Mail.SmtpClient client = 
        new System.Net.Mail.SmtpClient("yoursmtp.server.com");
    // foreach row in datatable{
    System.Net.Mail.MailMessage message = 
        new System.Net.Mail.MailMessage("Your Name <from@domain.com>", "Recipients Name <to@domain.com>", "subject", "body");
    // }
    client.Send(message);
