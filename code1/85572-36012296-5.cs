    public static bool IsValidEmailAddress(string emailAddress)
    {
        bool MethodResult = false;
        try
        {
            MailAddress m = new MailAddress(emailAddress);
    
            MethodResult = m.Address == emailAddress;
    
        }
        catch //(Exception ex)
        {
            //ex.HandleException();
        }
        return MethodResult;
    }
    public static List<string> GetInvalidEmailAddresses(List<string> recipients)
    {
        List<string> MethodResult = null;
        try
        {
            List<string> InvalidEmailAddresses = new List<string>();
    
            foreach (string Recipient in recipients)
            {
                if (!IsValidEmail(Recipient) && !InvalidEmailAddresses.Contains(Recipient))
                {
                    InvalidEmailAddresses.Add(Recipient);
    
                }
    
            }
    
            MethodResult = InvalidEmailAddresses;
    
        }
        catch //(Exception ex)
        {
            //ex.HandleException();
        }
        return MethodResult;
    }
