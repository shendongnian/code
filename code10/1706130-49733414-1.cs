            private static readonly ImapClient _client = new ImapX.ImapClient(ServerImapName, ImapPort, ImapProtocol, false);
            if (!_client.Connect())
            {
                throw new Exception("Error on conncting to the Email server.");
            }
            if (!_client.Login(User, Password))
            {
                throw new Exception("Impossible to login to the Email server.");
            }
            public static List<string> GetInboxEmails()
        {
            var lstInEmails = new List<string>();
            // select the inbox folder
            Folder inbox = _client.Folders.Inbox;
            if (inbox.Exists > 0)
            {
                var arrMsg = inbox.Search("ALL", ImapX.Enums.MessageFetchMode.Full);
                foreach (var msg in arrMsg)
                {
                    var subject = msg.Subject;
                    var mailBody = msg.Body.HasHtml ? msg.Body.Html : msg.Body.Text;
                    lstInEmails.Add(string.Concat(subject, " - ", mailBody );
                }
            }
            return lstInEmails;
        }
