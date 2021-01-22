    public class ModeratorUtils
    {
        private static readonly HashSet<int> _LockedPosts = new HashSet<int>();
        public void ModeratePost(int postId)
        {
            bool lockedByMe = false;
            try
            {
                lock (_LockedPosts)
                {
                    lockedByMe = _LockedPosts.Add(postId);
                }
                if (lockedByMe)
                {
                    // do your editing
                }
                else
                {
                    // sorry, can't edit at this time
                }
            }
            finally
            {
                if (lockedByMe)
                {
                    lock (_LockedPosts)
                    {
                        _LockedPosts.Remove(postId);
                    }
                }
            }
        }
    }
