    using (var client = new ImapClient ()) {
        client.Connect ("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
        client.Authenticate ("username", "password");
        
        client.Inbox.Open (FolderAccess.ReadWrite);
        
        foreach (var uid in client.Inbox.Search (SearchQuery.GMailRawSearch ("Category:Primary")) {
            var message = client.Inbox.GetMessage (uid);
        }
        foreach (var uid in client.Inbox.Search (SearchQuery.GMailRawSearch ("Category:Promotions")) {
            var message = client.Inbox.GetMessage (uid);
        }
        client.Disconnect (true);
    }
