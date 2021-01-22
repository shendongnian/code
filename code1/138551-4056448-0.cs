    public static void Buzz(string message)
    {
        string from, to, pass;
        from = "youracc@gmail.com";
        to = "buzz@gmail.com";
        pass = "yourpass";
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(from, pass)
        };
        smtp.Send(from, to, message, String.Empty);
    }
