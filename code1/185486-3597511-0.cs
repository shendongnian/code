     ImapX.ImapClient client = new ImapX.ImapClient("imap.gmail.com", 993, true);
            bool result = false;
            result = client.Connection();
            if (result)
                MessageBox.Show("Connection Established");
            result = client.LogIn(textBox1.Text, textBox2.Text);
            if (result)
            {
                MessageBox.Show("Logged in");
                ImapX.FolderCollection folders = client.Folders;
                ImapX.MessageCollection messages = client.Folders["INBOX"].Search("UNSEEN", true); //true - means all message parts will be received from server
                int unread = messages.Count;
                string unseen = unread.ToString();
                button1.Text = unseen;
            }
