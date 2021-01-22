    public static bool isEmail(string emailAddress)
    {
       if(string.IsNullOrEmpty(emailAddress))
          return false;
    
       Regex EmailAddress = new Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
       
       return EmailAddress.IsMatch(emailAddress);
    }
