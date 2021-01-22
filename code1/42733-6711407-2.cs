    // Connect to the IMAP server. The 'true' parameter specifies to use SSL
    // which is important (for Gmail at least)
    ImapClient ic = new ImapClient("imap.gmail.com", "name@gmail.com", "pass",
                    ImapClient.AuthMethods.Login, 993, true);
    // Select a mailbox. Case-insensitive
    ic.SelectMailbox("INBOX");
    Console.WriteLine(ic.GetMessageCount());
    // Get the first *11* messages. 0 is the first message;
    // and it also includes the 10th message, which is really the eleventh ;)
    // MailMessage represents, well, a message in your mailbox
    MailMessage[] mm = ic.GetMessages(0, 10);
    foreach (MailMessage m in mm)
    {
        Console.WriteLine(m.Subject);
    }
    // Probably wiser to use a using statement
    ic.Dispose();
