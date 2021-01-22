    string[] userData = new string[4];
    
    // fill the userData array with the information we need for subsequent requests
    userData[0] = ...; // data we need
    userData[1] = ...; // other data, etc
    
    // create a Forms Auth ticket with the username and the user data. 
    FormsAuthenticationTicket formsTicket = new FormsAuthenticationTicket(
        1,
        username,
        DateTime.Now,
        DateTime.Now.AddMinutes(DefaultTimeout),
        true,
        string.Join(UserDataDelimiter, userData)
        );
    
    // encrypt the ticket
    string encryptedTicket = FormsAuthentication.Encrypt(formsTicket);
