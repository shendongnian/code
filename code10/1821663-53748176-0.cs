    SmtpClient client = new SmtpClient('smtp.domain.com',25);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = true;
        client.Credentials = new NetworkCredential('username', 'password');
        client.EnableSsl = false;
        client.Send(mm);
