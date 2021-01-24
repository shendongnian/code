    var uids = Client.Inbox.Search (SearchQuery.All);
    var items = Client.Inbox.Fetch (uids, MessageSummaryItems.InternalDate | MessageSummaryItems.Flags);
    foreach (var item in items)
    {
        var message = Client.Inbox.GetMessage (item.UniqueId);
        Client2.Inbox.Append (message, item.Flags.Value, item.InternalDate.Value);
    }
