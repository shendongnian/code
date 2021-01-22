    public class ModeratorUtils
    {
        private static readonly HashSet<int> _LockedPosts = new HashSet<int>();
        // ...
        public void ModeratePost(int postId)
        {
            bool canEdit;
            lock (_LockedPosts)
            {
                canEdit = _LockedPosts.Add(postId);
            }
            if (canEdit)
            {
                // do your editing...
                lock (_LockedPosts)
                {
                    _LockedPosts.Remove(postId);
                }
            }
            else
            {
                // sorry, can't edit at this time
            }
        }
    }
