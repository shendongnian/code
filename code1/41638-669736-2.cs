    using(Pop3 pop3 = new Pop3())
    {
        Pop3 pop3 = new Pop3();
        pop3.Connect("mail.host.com");           // Connect to the server 
    	
    	pop3.User = "lesnikowski";               // Login
        pop3.Password = "password";
        pop3.Login();
    
        foreach(string uid in pop3.GetAll())
        {
            // Receive mail
            ISimpleMailMessage mail = new MailBuilder()
    			.CreateFromEml(pop3.GetMessageByUID(uid));
            Console.WriteLine( mail.Subject );
        }
        pop3.Close(true);	
    }
