    using System;
    using System.Net;
    using System.Threading;
    using MailKit.Net.Imap;
    using MailKit.Search;
    using MailKit;
    using MimeKit;
    namespace TestClient {
        class Program
        {
            public static void Main (string[] args)
            {
                using (var client = new ImapClient ()) {
                    var credentials = new NetworkCredential ("joey", "password");
                    var uri = new Uri ("imaps://imap.gmail.com");
                    using (var cancel = new CancellationTokenSource ()) {
                        client.Connect (uri, cancel.Token);
                        // If you want to disable an authentication mechanism,
                        // you can do so by removing the mechanism like this:
                        client.AuthenticationMechanisms.Remove ("XOAUTH");
                        client.Authenticate (credentials, cancel.Token);
                        // The Inbox folder is always available...
                        var inbox = client.Inbox;
                        inbox.Open (FolderAccess.ReadOnly, cancel.Token);
                        Console.WriteLine ("Total messages: {0}", inbox.Count);
                        Console.WriteLine ("Recent messages: {0}", inbox.Recent);
                        // download each message based on the message index
                        for (int i = 0; i < inbox.Count; i++) {
                            var message = inbox.GetMessage (i, cancel.Token);
                            Console.WriteLine ("Subject: {0}", message.Subject);
                        }
                        // download them in reverse order...
                        var orderBy = new [] { OrderBy.ReverseArrival };
                        foreach (var uid in inbox.Search (SearchQuery.All, orderBy, cancel.Token)) {
                            var message = inbox.GetMessage (i, cancel.Token);
                            Console.WriteLine ("Subject: {0}", message.Subject);
                        }
                        // let's try searching for some messages...
                        var query = SearchQuery.DeliveredAfter (DateTime.Parse ("2013-01-12"))
                            .And (SearchQuery.SubjectContains ("MailKit"))
                            .And (SearchQuery.Seen);
                        foreach (var uid in inbox.Search (query, cancel.Token)) {
                            var message = inbox.GetMessage (uid, cancel.Token);
                            Console.WriteLine ("[match] {0}: {1}", uid, message.Subject);
                        }
                        client.Disconnect (true, cancel.Token);
                    }
                }
            }
        }
    }
