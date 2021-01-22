    using (var client = new IMAP_Client())
    {
        client.Connect(_hostname, _port, _useSsl);
        client.Authenticate(_username, _password);
        client.SelectFolder("INBOX");
         var sequence = new IMAP_SequenceSet();
        sequence.Parse("0:10");
        var fetchItems = client.FetchMessages(sequence, IMAP_FetchItem_Flags.Envelope | IMAP_FetchItlags.UID,
                                            false, true);
        foreach (var fetchItem in fetchItems)
        {
            Console.Out.WriteLine("message.UID = {0}", fetchItem.UID);
            Console.Out.WriteLine("message.Envelope.From = {0}", fetchItem.Envelope.From);
            Console.Out.WriteLine("message.Envelope.To = {0}", fetchItem.Envelope.To);
            Console.Out.WriteLine("message.Envelope.Subject = {0}", fetchItem.Envelope.Subject);
            Console.Out.WriteLine("message.Envelope.MessageID = {0}", fetchItem.Envelope.MessageID);
        }
        Console.Out.WriteLine("Fetching bodies");
        foreach (var fetchItem in client.FetchMessages(sequence, IMAP_FetchItem_Flags.All, false, true)
        {             
            var email = LumiSoft.Net.Mail.Mail_Message.ParseFromByte(fetchItem.MessageData);             
            Console.Out.WriteLine("email.BodyText = {0}", email.BodyText);
            
        }
    }
