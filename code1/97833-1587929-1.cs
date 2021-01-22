    public string GetTextBody(string htmlBody)
    {
        CDO.Message msg = new CDO.Message();
        msg.AutoGenerateTextBody = true;
        msg.HTMLBody = htmlBody;
        return msg.TextBody;
    }
