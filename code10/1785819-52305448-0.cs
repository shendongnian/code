    SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.UseDefaultCredentials = false;
    client.EnableSsl = true;
    client.Credentials = new System.Net.NetworkCredential("myemail@outlook.com", "mypassword");
    client.Send(message);
