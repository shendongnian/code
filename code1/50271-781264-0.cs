    static readonly HashSet<int> _LockedPosts = new HashSet<int>();
    // ...
    bool canEdit;
    lock (_LockedPosts)
    {
        canEdit = _LockedPosts.Add(postId);
    }
    if (canEdit)
    {
        // do your editing
        lock (_LockedPosts)
        {
            _LockedPosts.Remove(postId);
        }
    }
    else
    {
        // sorry, can't edit at this time
    }
