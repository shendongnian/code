    public bool IsValidEmailAddress (string email)
    {
        try
        {
            MailAddress ma = new MailAddress (email);
    
            return true;
        }
       catch
       {
            return false;
       }
    }
