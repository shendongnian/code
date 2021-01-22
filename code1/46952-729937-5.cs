    public class SuspendLatch
    {
        private IDictionary<Guid, SuspendLatchToken> tokens = new Dictionary<Guid, SuspendLatchToken>();
        public SuspendLatchToken GetToken()
        {
            SuspendLatchToken token = new SuspendLatchToken(this);
            tokens.Add(token.Key, token);
            return token;
        }
        public bool HasOutstandingTokens
        {
            get { return tokens.Count > 0; }
        }
        public void CancelToken(SuspendLatchToken token)
        {
            tokens.Remove(token.Key);
        }
        public class SuspendLatchToken : IDisposable
        {
            private bool disposed = false;
            private Guid key = Guid.NewGuid();
            private SuspendLatch parent;
            internal SuspendLatchToken(SuspendLatch parent)
            {
                this.parent = parent;
            }
            public Guid Key
            {
                get { return this.key; }
            }
            public override bool Equals(object obj)
            {
                SuspendLatchToken other = obj as SuspendLatchToken;
                if (other != null)
                {
                    return Key.Equals(other.Key);
                }
                else
                {
                    return false;
                }
            }
            public override int GetHashCode()
            {
                return Key.GetHashCode();
            }
            public override string ToString()
            {
                return Key.ToString();
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        // Dispose managed resources.
                        parent.CancelToken(this);
                    }
                    // There are no unmanaged resources to release, but
                    // if we add them, they need to be released here.
                }
                disposed = true;
                // If it is available, make the call to the
                // base class's Dispose(Boolean) method
                //base.Dispose(disposing);
            }
        }
    }
