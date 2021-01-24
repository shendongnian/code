    using System;
    using System.Collections.Generic;
    using GemBox.Email;
    using GemBox.Email.Imap;
    namespace IMapAccess
    {
        class Program
        {
            static void Main(string[] args)
            {
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                using (ImapClient imap = new ImapClient("imap.gmail.com", 993)){
                    imap.ConnectTimeout = TimeSpan.FromSeconds(10);
                    imap.Connect();
                    imap.Authenticate("MyEmail@gmail.com", "MySuperSecretPassword", ImapAuthentication.Native);
                    imap.SelectInbox();
                    IList<int> messages = imap.SearchMessageNumbers("UNSEEN");
                    Console.WriteLine($"Number of unseen messages {messages.Count}");
                }
            }
        }
    }
