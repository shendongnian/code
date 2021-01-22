    //====Imap sample================================//
    //You can set default value by Default property
    ImapClient.Default.UserName = "your server name";
    ImapClient cl = new ImapClient("your server name");
    cl.UserName = "your name";
    cl.Password = "pass";
    cl.Ssl = false;
    if (cl.Authenticate() == true)
    {
        Int32 MailIndex = 1;
        //Get all folder
        List<ImapFolder> l = cl.GetAllFolders();
        ImapFolder rFolder = cl.SelectFolder("INBOX");
        MailMessage mg = cl.GetMessage(MailIndex);
    }
    
    //Delete selected mail from mailbox
    ImapClient pop = new ImapClient("server name", 110, "user name", "pass");
    pop.AuthenticateMode = Pop3AuthenticateMode.Pop;
    Int64[] DeleteIndexList = new.....//It depend on your needs
    cl.DeleteEMail(DeleteIndexList);
    
    //Get unread message list from GMail
    using (ImapClient cl = new ImapClient("imap.gmail.com")) 
    {
        cl.Port = 993;
        cl.Ssl = true; 
        cl.UserName = "xxxxx";
        cl.Password = "yyyyy";
        var bl = cl.Authenticate();
        if (bl == true)
        {
            //Select folder
            ImapFolder folder = cl.SelectFolder("[Gmail]/All Mail");
            //Search Unread
            SearchResult list = cl.ExecuteSearch("UNSEEN UNDELETED");
            //Get all unread mail
            for (int i = 0; i < list.MailIndexList.Count; i++)
            {
                mg = cl.GetMessage(list.MailIndexList[i]);
            }
        }
        //Change mail read state as read
        cl.ExecuteStore(1, StoreItem.FlagsReplace, "UNSEEN")
    }
    
    
    //Create draft mail to mailbox
    using (ImapClient cl = new ImapClient("imap.gmail.com")) 
    {
        cl.Port = 993;
        cl.Ssl = true; 
        cl.UserName = "xxxxx";
        cl.Password = "yyyyy";
        var bl = cl.Authenticate();
        if (bl == true)
        {
            var smg = new SmtpMessage("from mail address", "to mail addres list"
                , "cc mail address list", "This is a test mail.", "Hi.It is my draft mail");
            cl.ExecuteAppend("GMail/Drafts", smg.GetDataText(), "\\Draft", DateTimeOffset.Now); 
        }
    }
    
    //Idle
    using (var cl = new ImapClient("imap.gmail.com", 993, "user name", "pass"))
    {
        cl.Ssl = true;
        cl.ReceiveTimeout = 10 * 60 * 1000;//10 minute
        if (cl.Authenticate() == true)
        {
            var l = cl.GetAllFolders();
            ImapFolder r = cl.SelectFolder("INBOX");
            //You must dispose ImapIdleCommand object
            using (var cm = cl.CreateImapIdleCommand()) Caution! Ensure dispose command object
            {
                //This handler is invoked when you receive a mesage from server
                cm.MessageReceived += (Object o, ImapIdleCommandMessageReceivedEventArgs e) =>
                {
                    foreach (var mg in e.MessageList)
                    {
                        String text = String.Format("Type is {0} Number is {1}", mg.MessageType, mg.Number);
                        Console.WriteLine(text);
                    }
                };
                cl.ExecuteIdle(cm);
                while (true)
                {
                    var line = Console.ReadLine();
                    if (line == "done")
                    {
                        cl.ExecuteDone(cm);
                        break;
                    }
                }
            }
        }
    }
