    System.Messaging.Message[] messages = messageQueue.GetAllMessages();
    
    foreach (System.Messaging.Message message in messages)
    {
        System.IO.StreamReader sr = new System.IO.StreamReader(message.BodyStream);
        Console.WriteLine(sr.ReadToEnd());
    }
