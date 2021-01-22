    //Satrt Send Email Function
    public string SendMail(string toList, string from, string ccList,
        string subject, string body)
    {
        MailMessage message = new MailMessage();
        SmtpClient smtpClient = new SmtpClient();
        string msg = string.Empty;
        try
        {
            MailAddress fromAddress = new MailAddress(from);
            message.From = fromAddress;
            message.To.Add(toList);
            if (ccList != null && ccList != string.Empty)
                message.CC.Add(ccList);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            // We use gmail as our smtp client
            smtpClient.Host = "smtp.gmail.com";   
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(
                "Your Gmail User Name", "Your Gmail Password");
            smtpClient.Send(message);
            msg = "Successful<BR>";
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        return msg;
    }
    //End Send Email Function
