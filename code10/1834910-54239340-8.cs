    void OnMessageFlagsChanged (object sender, MessageFlagsChangedEventArgs e)
    {
        cache.Update (e.Index, e.Flags, e.ModSeq);
    }
    
    void OnMessageExpunged (object sender, MessageExpungedEventArgs e)
    {
        cache.Remove (e.Index);
    }
    
    void OnMessagesVanished (object sender, MessagesVanishedEventArgs e)
    {
        cache.RemoveRange (e.UniqueIds);
    }
