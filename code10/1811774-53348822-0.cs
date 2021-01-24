    // Create an instance of MapiMessage from file
    MapiMessage msg = MapiMessage.FromFile(dataDir + @"message.msg");
    
    // Get subject
    Console.WriteLine("Subject:" + msg.Subject);
    
    // Get from address
    Console.WriteLine("Sender:" + msg.SenderEmailAddress);
    Console.WriteLine("Sender SMTP:" + msg.SenderSmtpAddress);
    
    // Get body
    Console.WriteLine("Body" + msg.Body);
    
    // Get recipients information
    Console.WriteLine("Recipient: " + msg.Recipients);
    
    // Get attachments
    foreach (MapiAttachment att in msg.Attachments)
    {
        Console.Write("Attachment Name: " + att.FileName);
        Console.Write("Attachment Display Name: " + att.DisplayName);
    }
