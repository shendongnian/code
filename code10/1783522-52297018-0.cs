    public class UserScopeLocker : IDisposable
    {
        private static readonly object _obj = new object();
        private static ICollection<string> UserQueue = new HashSet<string>();
        private readonly string _userId;
        protected UserScopeLocker(string userId)
        {
            this._userId = userId;
        }
        public static UserScopeLocker Acquire(string userId)
        {
            while (true)
            {
                lock (_obj)
                {
                    if (UserQueue.Contains(userId))
                    {
                        continue;
                    }
                    UserQueue.Add(userId);
                    return new UserScopeLocker(userId);
                }
            }
        }
        public void Dispose()
        {
            lock (_obj)
            {
                UserQueue.Remove(this._userId);
            }
        }
    }
