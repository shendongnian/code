    using(Imap imap = new Imap())
    {
        imap.ConnectSSL("imap.gmail.com");
    
        imap.User = "user";
        imap.Password = "password";
        imap.Login();
    
        imap.SelectInbox();
        List<long> uids = imap.SearchFlag(Flag.Unseen);
        foreach (long uid in uids)
        {
            string eml = imap.GetMessageByUID(uid);
            ISimpleMailMessage message = new SimpleMailMessageBuilder()
                .CreateFromEml(eml);
            Console.WriteLine(message.Subject);
            Console.WriteLine(message.TextDataString);
        }
        imap.Close(true);
    }
