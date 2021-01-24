    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string user = GetUserDetails();
        List<string> recipients = GetAllRecipient();
        string html = GetHtmlTemplate();
        foreach (var recipient in recipients)
        {
            html = html.Replace("<<SOME TAG>>", recipient);
            SendEmail(recipient, html);
        }
    }
    
    public string GetUserDetails()
    {
        return txtUsername.Text;
    }
    
    public List<string> GetAllRecipient()
    {
        //TODO: Get all your recipient from database or excel
        //e,g, 
        return new List<string>() {"someemail@address.com", "anotheremail@address.com"};
    }
    
    public void SendEmail(string recipient, string html)
    {
        //TODO: Send the email
    }
