    using(Pop3 pop3 = new Pop3())
    {
        pop3.Connect("mail.host.com");    // Connect to the server 
        pop3.Login("user", "password");
    
        foreach(string uid in pop3.GetAll())
        {
            // Receive mail
            IMail mail = new MailBuilder()
       .CreateFromEml(pop3.GetMessageByUID(uid));
            Console.WriteLine(mail.Subject);
        }
        pop3.Close(true); 
    }
