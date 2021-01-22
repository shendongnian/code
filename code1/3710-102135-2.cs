    // 
    // create client, connect and log in 
    Pop3 client = new Pop3();
    client.Connect("pop3.example.org");
    client.Login("username", "password");
    
    // get message list 
    Pop3MessageCollection list = client.GetMessageList();
    
    if (list.Count == 0)
    {
        Console.WriteLine("There are no messages in the mailbox.");
    }
    else 
    {
        // download the first message 
        MailMessage message = client.GetMailMessage(list[0].SequenceNumber);
        ...
    }
    
    client.Disconnect();
