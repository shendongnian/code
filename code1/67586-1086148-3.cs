    public abstract class Scope<T> : IDisposable
        where T : IDisposable
    {
        private bool disposed = false;
        [ThreadStatic]
        private static Stack<ScopeItem<T>> stack = null;
        public static T Current
        {
            get { return stack.Peek().Item; }
        }
        internal static string CurrentKey
        {
            get { return stack.Peek().Key; }
        }
        protected internal ScopeItem<T> CurrentScopeItem
        {
            get { return stack.Peek(); }
        }
        
        protected void InitialiseScope(string key)
        {
            if (stack == null)
            {
                stack = new Stack<ScopeItem<T>>();
            }
            // Only create a new item on the stack if this
            // is different to the current ambient item
            if (stack.Count == 0 || stack.Peek().Key != key)
            {
                stack.Push(new ScopeItem<T>(1, CreateItem(), key));
            }
            else
            {
                stack.Peek().UserCount++;
            }            
        }
        protected abstract T CreateItem();
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // If there are no users for the current item
                    // in the stack, pop it
                    if (stack.Peek().UserCount == 1)
                    {
                        stack.Pop().Item.Dispose();
                    }
                    else
                    {
                        stack.Peek().UserCount--;
                    }
                }
                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
            disposed = true;
        }
    }
    public class ScopeItem<T> where T : IDisposable
    {
        private int userCount;
        private T item;
        private string key;
        public ScopeItem(int userCount, T item, string key)
        {
            this.userCount = userCount;
            this.item = item;
            this.key = key;
        }
        public int UserCount
        {
            get { return this.userCount; }
            set { this.userCount = value; }
        }
        public T Item
        {
            get { return this.item; }
            set { this.item = value; }
        }
        public string Key
        {
            get { return this.key; }
            set { this.key = value; }
        }
    }
    public class ConnectionScope : Scope<IDbConnection>
	{
		private readonly string connectionString = "";
		private readonly string providerName = "";
		public ConnectionScope(string connectionString, string providerName)
		{
			this.connectionString = connectionString;
			this.providerName = providerName;
			InitialiseScope(string.Format("{0}:{1}", connectionString, providerName));
		}
	    public ConnectionScope(IConnectionDetailsProvider connectionDetails)
            : this(connectionDetails.ConnectionString, connectionDetails.ConnectionProvider)
	    {
	    }
	    protected override IDbConnection CreateItem()
		{
			IDbConnection connection = DbProviderFactories.GetFactory(providerName).CreateConnection();
			connection.ConnectionString = connectionString;
			connection.Open();
			return connection;
		}
	}
