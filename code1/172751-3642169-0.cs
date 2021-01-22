    using(Pop3 pop3 = new Pop3())
    {
        pop3.ConnectSSL("pop3.server.com");              
        pop3.Login("user", "password");
    
        foreach (string uid in pop3.GetAll())
        {
            IMail email = new MailBuilder()
                .CreateFromEml(pop3.GetMessageByUID(uid));
            Console.WriteLine(email.Subject);
        }
        pop3.Close(true);
    }	            
