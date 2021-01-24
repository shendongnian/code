    string ObtainPassword()
    {
        string password;
        string passwordErrorMessage;
        while(true)
        {
            Console.Write("Password: ");
            password = Console.ReadLine();
            passwordErrorMessage = ValidatePassword(password);
            if (passwordErrorMessage == null)
                return password;
    
            Console.WriteLine($"\r\n*** {passwordErrorMessage}");
        }
    }
