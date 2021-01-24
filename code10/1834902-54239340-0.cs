    folder.Open (ImapFolder.ReadWrite);
    var all = folder.Search (SearchQuery.All);
    var known = cache.GetKnownUids ();
    var missing = new UniqueIdSet (SortOrder.Ascending);
    
    // purge messages from our cache that have been purged on the remote IMAP server
    foreach (var uid in known) {
        if (!all.Contains (uid))
            cache.Remove (uid);
    }
    
    // figure out which messages we are missing in our cache
    foreach (var uid in all) {
        if (!known.Contains (uid))
            missing.Add (uid);
    }
    
    // fetch the summary information for the messages we are missing
    var newMessages = folder.Fetch (missing, MessageSummaryItems.Full | MessageSummaryItems.UniqueId);
    foreach (var message in newMessages)
       cache.Add (message);
