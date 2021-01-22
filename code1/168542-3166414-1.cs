    // create client, connect and log in  
    Pop3 client = new Pop3();
    client.Connect("pop3.example.org");
    client.Login("username", "password");
    
    // get message list - full headers  
    Pop3MessageCollection messageList = client.GetMessageList();
    
    foreach (Pop3MessageInfo messageInfo in messageList)
    {
       // download message
       MailMessage message = client.GetMailMessage(messageInfo.SequenceNumber);
    
       // store it to the database... 
       // depends on your DB structure. 
       // message.Save(stream) or message.ToByteArray() would be handy
       ...
    }
    
    client.Disconnect();
