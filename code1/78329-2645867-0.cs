    using(Imap imap = new Imap())
    {
        imap.Connect("imap.server.com");
        imap.Login("user", "password");
    
        imap.SelectInbox();
        List<long> uidList = imap.SearchFlag(Flag.Unseen);
        foreach (long uid in uidList)
        {
            IMail mail = new MailBuilder()
                .CreateFromEml(imap.GetMessageByUID(uid));
            Console.WriteLine(mail.Subject);
        }
        imap.Close(true);
    }
