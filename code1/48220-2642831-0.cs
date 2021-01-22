    using (Imap client = new Imap())
    {
        client.ConnectSSL("imap.server.com");
        client.Login("user@server.com", "password");
    
        FolderStatus folderStatus = client.SelectInbox();
        Console.WriteLine("Total message count: {0}",
            folderStatus.MessageCount);
    	
        while(true)
        {
            FolderStatus currentStatus = client.Idle();
            Console.WriteLine("Total message count: {0}",
                    currentStatus.MessageCount);
            foreach(long uid in client.SearchFlag(Flag.Unseen))
            {
                IMail email = new MailBuilder().CreateFromEml(
                    client.GetHeadersByUID(uid));
                Console.WriteLine(email.Subject);
            }
        }
        client.Close();
    }
