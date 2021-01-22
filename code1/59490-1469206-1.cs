    using Rebex.Mail;
    using Rebex.Net;
    ...
    // create the POP3 client
    Pop3 client = new Pop3();
    try
    {
       
       // Connect securely using explicit SSL. 
       // Use the third argument to specify additional SSL parameters. 
       Console.WriteLine("Connecting to the POP3 server...");
       client.Connect("pop.gmail.com", 995, null, Pop3Security.Implicit);
       
       // login and password
       client.Login(email, password);
       
       // get the number of messages
       Console.WriteLine("{0} messages found.", client.GetMessageCount());
       
       // -----------------
       // list messages
       // -----------------
       
       // list all messages
       ListPop3MessagesFast(client); // unique IDs and size only   
       //ListPop3MessagesFullHeaders(client); // full headers
    }
    finally
    {
       // leave the server alone
       client.Disconnect();      
    }
    public static void ListPop3MessagesFast(Pop3 client)
    {
       Console.WriteLine("Fetching message list...");
       
       // let's download only what we can get fast
       Pop3MessageCollection messages = 
          client.GetMessageList(Pop3ListFields.Fast);
    
       // display basic info about each message
       Console.WriteLine("UID | Sequence number | Length");
       foreach (Pop3MessageInfo messageInfo in messages)
       {
          // display header info
          Console.WriteLine
          (
             "{0} | {1} | {2} ",
             messageInfo.UniqueId,
             messageInfo.SequenceNumber,
             messageInfo.Length
          );
         
          // or download the whole message
          MailMessage mailMessage = client.GetMailMessage(messageInfo.SequenceNumber);
       }   
    }
