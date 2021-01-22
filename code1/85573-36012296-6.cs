    protected List<string> GetRecipients() // Gets recipients from TextBox named `TxtRecipients`
    {
        List<string> MethodResult = null;
        try
        {
            List<string> Recipients = TxtRecipients.Text.Replace(",",";").Replace(" ", "").Split(';').ToList();
            List<string> RecipientsCleaned = new List<string>();
            foreach (string Recipient in RecipientsCleaned)
            {
                if (!String.IsNullOrWhiteSpace(Recipient))
                {
                    RecipientsNoBlanks.Add(Recipient);
                }
            }
            MethodResult = RecipientsNoBlanks;
        }
        catch//(Exception ex)
        {
            //ex.HandleException();
        }
        return MethodResult;
    }
    public static bool IsValidEmailAddresses(List<string> recipients)
    {
        List<string> InvalidAddresses = GetInvalidEmailAddresses(recipients);
        return InvalidAddresses != null && InvalidAddresses.Count == 0;
    }
    public static List<string> GetInvalidEmailAddresses(List<string> recipients)
    {
        List<string> MethodResult = null;
        try
        {
            List<string> InvalidEmailAddresses = new List<string>();
            foreach (string Recipient in recipients)
            {
                if (!(new EmailAddressAttribute().IsValid(Recipient)) && !InvalidEmailAddresses.Contains(Recipient))
                {
                    InvalidEmailAddresses.Add(Recipient);
                }
            }
            MethodResult = InvalidEmailAddresses;
        }
        catch//(Exception ex)
        {
            //ex.HandleException();
        }
        return MethodResult;
    }
