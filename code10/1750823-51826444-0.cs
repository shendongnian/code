    [Microsoft.SqlServer.Server.SqlProcedure()]
    public static void spSendMail(string recipients, string subject, string fromto, string body)
    {
        MailMessage message = new MailMessage(fromto, recipients);
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
        string msg = string.Empty;
        try
        {
            message.From = new MailAddress(fromto);
            message.To.Add(recipients);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(fromto, "779957082");
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            msg = "Message ENvoyé !";
            Console.WriteLine(msg);
            //Console.ReadKey();
        }
        catch (Exception ex)
        {
            msg = ex.Message;
            Console.WriteLine(msg);
            //Console.ReadKey();
        }
    }
