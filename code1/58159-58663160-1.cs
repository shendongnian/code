    using(FileStream stream = new FileStream("ExampleMbox.mbox", FileMode.Open, FileAccess.Read))
    {
        using(MboxrdStorageReader reader = new MboxrdStorageReader(stream, false))
        {
            // Start reading messages
            MailMessage message = reader.ReadNextMessage();
    
            // Read all messages in a loop
            while (message != null)
            {
                // Manipulate message - show contents
                Console.WriteLine("Subject: " + message.Subject);
                // Save this message in EML or MSG format
                message.Save(message.Subject + ".eml", SaveOptions.DefaultEml);
                message.Save(message.Subject + ".msg", SaveOptions.DefaultMsgUnicode);
    
                // Get the next message
                message = reader.ReadNextMessage();
            }
        }
    }
