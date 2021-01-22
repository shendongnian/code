    Imap imap = new Imap();
    imap.Connect("mail.host.com");
    
    imap.User = "lesnikowski";;
    imap.Password = "password";
    imap.Login();
    
    imap.SelectInbox();
    List<long> uids = imap.SearchFlag(Flag.Unseen);
    foreach (long uid in uids)
    {
          string eml = imap.GetMessageByUID(uid);
          ISimpleMailMessage message = new SimpleMailMessageBuilder()
                    .CreateFromEml(eml);
          Console.WriteLine(message.Subject);
          Console.WriteLine(message.TextDataString); 
    }
    imap.Close(true);
