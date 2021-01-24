    var uidValidity = cache.GetUidValidity ();
    var known = cache.GetKnownUids ();
    UniqueIdSet missing;
    
    folder.MessageFlagsChanged += OnMessageFlagsChanged;
    
    if (client.Capabilities.HasFlag (ImapCapabilities.QuickResync)) {
        var highestModSeq = cache.GetHighestKnownModSeq ();
    
        folder.MessagesVanished += OnMessagesVanished;
    
        // This version of the Open() method will emit MessagesVanished and MessageFlagsChanged
        // for all messages that have been expunged or have changed since the last session.
        folder.Open (FolderAccess.ReadWrite, uidValidity, highestModSeq, known);
    } else {
        folder.MessageExpunged += OnMessageExpunged;
        folder.Open (ImapFolder.ReadWrite);
    
        if (folder.UidValidity != uidValidity) {
            // our cache is no longer valid, we'll need to start over from scratch
            cache.Clear ();
    
            missing = folder.Search (SearchQuery.All);
        } else {
            var all = folder.Search (SearchQuery.All);
    
            // purge messages from our cache that have been purged on the remote IMAP server
            foreach (var uid in known) {
                if (!all.Contains (uid))
                    cache.Remove (uid);
            }
    
            // sync flag changes since our last session
            known = cache.GetKnownUids ();
            if (known.Count > 0) {
                IList<IMessageSummary> changed;
                if (client.Capabilities.HasFlag (ImapCapabilities.CondStore)) {
                    var highestModSeq = cache.GetHighestKnownModSeq ();
                    changed = folder.Fetch (known, highestModSeq, MessageSummaryItems.Flags | MessageSummaryItems.ModSeq | MessageSummaryItems.UniqueId);
                } else {
                    changed = folder.Fetch (known, MessageSummaryItems.Flags | MessageSummaryItems.UniqueId);
                }
    
                foreach (var item in changed) {
                    // update the cache for this message
                    cache.Update (item);
                }
            }
    
            // figure out which messages we are missing in our cache
            missing = new UniqueIdSet (SortOrder.Ascending);
            foreach (var uid in all) {
                if (!known.Contains (uid))
                    missing.Add (uid);
            }
        }
    }
    
    // fetch the summary information for the messages we are missing
    var fields = MessageSummaryItems.Full | MessageSummaryItems.UniqueId;
    
    if (client.Capabilities.HasFlag (ImapCapabilities.CondStore))
        fields |= MessageSummaryItems.ModSeq;
    
    var newMessages = folder.Fetch (missing, fields);
    foreach (var message in newMessages)
        cache.Add (message);
