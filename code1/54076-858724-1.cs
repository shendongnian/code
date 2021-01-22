    // get the Forms Auth ticket object back from the encrypted Ticket
    FormsAuthenticationTicket formsTicket = FormsAuthentication.Decrypt(encryptedTicket);
    
    // split the user data back apart
    string[] userData = formsTicket.UserData.Split(new string[] { UserDataDelimiter }, StringSplitOptions.None);
    
    // verify that the username in the ticket matches the username that was sent with the request
    if (formsTicket.Name == expectedUsername)
    {
        // ticket is valid
        ...
    }
