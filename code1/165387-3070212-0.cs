    var popClient = new POPClient();
    popClient.Connect("pop.test.lt", 110, false);
    popClient.Authenticate("test@test.lt", "test");
    
    // Get OpenPop.Net message
    var messageInfo = popClient.GetMessage(1, false);
    
    // Covert raw message string into stream and create instance of SharpMessage from SharpMimeTools library
    var messageBytes = Encoding.ASCII.GetBytes(rawMessage);
    var messageStream = new MemoryStream(messageBytes);
    var message = new SharpMessage(messageStream);
    
    // Get decoded message and subject
    var messageText = message.Body;
    var messageSubject = message.Subject;
 
