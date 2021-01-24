    string message = "Hi, Your Password is: 123456. Thanks";
                
    string password = string.Empty;
    
    for (int i=0; i< message.Length; i++)
    {
        if (Char.IsDigit(message[i]))
            password += message[i];
    }
