    SmtpClient client = new SmtpClient();
    client.Credentials = new System.Net.NetworkCredential("username@gmail.com", "password");
    client.EnableSsl = true;
    client.Host = "smtp.gmail.com";
    client.Port = 465 or 587; 
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.Send(MailMessage);
