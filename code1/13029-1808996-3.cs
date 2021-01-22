    using(Imap imap = new Imap())
    {
    	imap.Connect("imap.company.com");
        imap.UseBestLogin("user", "password");
        
        imap.SelectInbox();
        List<long> uids = imap.Search(Flag.Unseen);
        foreach (long uid in uids)
        {
              var eml = imap.GetMessageByUID(uid);
              IMail message = new MailBuilder()
                        .CreateFromEml(eml);
    		
              Console.WriteLine(message.Subject);
              Console.WriteLine(message.Text); 
        }
        imap.Close(true);
    }
