    config.CacheFile = "";
        IMAPClient client = null;
        try
        {
            client = new IMAPClient(config, null, 5);
        }
        catch (IMAPException e)
        {
            Console.WriteLine(e.Message);
            return;
        }
        Console.WriteLine(DateTime.Now.ToString());
        IMAPFolder f = client.Folders["INBOX"];
        IMAPSearchResult sResult = f.Search(IMAPSearchQuery.QuickSearchUnread());
