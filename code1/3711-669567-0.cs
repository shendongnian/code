        Pop3 pop3 = new Pop3();
        pop3.User = "lesnikowski";               // Set user name and password
        pop3.Password = "password";
    
        pop3.Connect("mail.host.com");           // Connect to server and login
        pop3.Login();
        pop3.GetAccountStat();                   // Get account statistics
    
        SimpleMailMessageBuilder builder = new SimpleMailMessageBuilder();
    
        for(int i = 1; i<=pop3.MessageCount; i++)
        {
              // Receive an email
              ISimpleMailMessage mail = builder.CreateFromEml(pop3.GetMessage(i));
              Console.WriteLine( mail.Subject );
        }
        pop3.Close(false);
