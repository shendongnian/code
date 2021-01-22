    // connect and log in
    Imap imap = new Imap();
    imap.Connect("imap.gmail.com", 993, null, ImapSecurity.Implicit);
    imap.Login(username, password);
    
    // process messagess...
    ImapMessageCollection messages =
        client.GetMessageList(ImapListFields.Envelope);
    
    // display info about each message 
    Console.WriteLine("UID | From | To | Subject");
    foreach (ImapMessageInfo message in messages)
    {
        Console.WriteLine(
            "{0} | {1} | {2} | {3}",
            message.UniqueId,
            message.From,
            message.To,
            message.Subject);
    }
    
    // logout and disconnect
    imap.Disconnect();
