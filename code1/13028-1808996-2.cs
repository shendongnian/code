    using(Imap imap = new Imap())
    {
    	imap.Connect("imap.company.com");
        imap.Login("user", "password");
        
        imap.SelectInbox();
        List<long> uids = imap.SearchFlag(Flag.Unseen);
        foreach (long uid in uids)
        {
              string eml = imap.GetMessageByUID(uid);
              IMail message = new MailBuilder()
                        .CreateFromEml(eml);
    		
              Console.WriteLine(message.Subject);
              Console.WriteLine(message.TextDataString); 
        }
        imap.Close(true);
    }
