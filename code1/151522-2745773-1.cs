    public static bool sendEmail(string fromName, string fromEmail, string body, string subject, string toEmail) {
        String strReplyTo = fromEmail.Trim();
        String strTo = toEmail;
        String msgBodyTop = "Email from: " + @fromName + "(" + @fromEmail + ")\n"
                + "" + " " + DateTime.Now.ToLongTimeString()
                + " FROM " + HttpContext.Current.Request.Url.ToString + " : \n\n"
                + "---\n";
        MailMessage theMail = new MailMessage(fromEmail, strTo, subject, msgBodyTop + body);
        
        theMail.From = new MailAddress(strReplyTo, fromName);
        
        SmtpClient theClient = new SmtpClient(ConfigurationManager.AppSettings["SMTP"].ToString());
        theClient.Send(theMail);
        return true;
    }
