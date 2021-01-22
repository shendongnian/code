    using(Imap imap = new Imap())
    {
        imap.ConnectSSL("imapServer");
        imap.Login("user", "password");
    
        imap.SelectInbox();
        List<long> uids = imap.SearchFlag(Flag.Unseen);
        foreach (long uid in uids)
        {
            string eml = imap.GetMessageByUID(uid);
            IMail email = new MailBuilder()
                .CreateFromEml(eml);
            Console.WriteLine(email.Subject);
            Console.WriteLine(email.TextDataString);
        }
        imap.Close(true);
    }
