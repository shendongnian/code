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
