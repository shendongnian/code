    public string GetTextBody(string htmlBody)
    {
        CDO.MessageClass msg = new CDO.MessageClass();
        msg.AutoGenerateTextBody = true;
        msg.HTMLBody = htmlBody;
        return msg.TextBody;
    }
