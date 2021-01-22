    // your public global settings singleton, no big surprises here
    // except possibly thread safe locking [shrug] if you are singlethreaded
    // you can simplify this model further
    public class GlobalSettings
    {
        // singleton synchronization and instance reference
        private static readonly object _instanceSyncRoot = new object ();
        private static readonly GlobalSettings _instance = null;
        // isntance-based synchronization and values
        private readonly object _syncRoot = new object ();
        private string _cultureName = string.Empty;
        // gets public static instance
        public static GlobalSettings Current
        {
            get
            {
                lock (_instanceSyncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new GlobalSettings ();
                    }
                }
                return _instance;
            }
        }
        // gets public culture name
        public string CultureName 
        {
            get { lock (_syncRoot) { return _cultureName; } }
            set { lock (_syncRoot) { _cultureName = value; } }
        }
        // private constructor to re-inforce singleton semantics
        private GlobalSettings () { }
    }
