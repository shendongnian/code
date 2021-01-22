    public sealded class PluginService
    {
    
        static PluginService() { }
        //make the instance readonly
        private static readonly PluginService _instance = new PluginService();
        public static PluginService Instance { get { return _instance; } }
        // make the flag volatile
        private static volatile bool s_initialized = false;
        private static object s_lock = new object();
        // you still need to synchronize when you're initializing
        public void Initialize() {
            lock(s_lock)
            {
                if (!s_initialized)
                {
                    // initialize
                    s_initialized = true;
                }
            }
        }
    }
