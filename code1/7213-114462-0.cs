    internal sealed class SektionCache : CacheBase
    {
        //public static readonly SektionCache Instance = new SektionCache();
    
        // this template is better ( safer ) than the previous one, for thread-safe singleton patter >>>
        private static SektionCache defaultInstance;
        private static object readonly lockObject = new object();
        public static SektionCach Default {
            get {
                SektionCach result = defaultInstance;
                if ( null == result ) {
                    lock( lockObject ) {
                        if ( null == result ) {
                            defaultInstance = result = new SektionCache();
                        }
                    }
                }
    
                return result;
            }
        }
        // <<< this template is better ( safer ) than the previous one
    
        //private static readonly object lockObject = new object();
        //private static bool isUpdating;
        //private IEnumerable<Sektion> sektioner;
    
        // this declaration is enough
        private volatile IEnumerable<Sektion> sektioner;
    
        // no static constructor is required >>>
        //static SektionCache()
        //{
        //    UpdateCache();
        //}
        // <<< no static constructor is required
    
        // I think, you can use getter and setter for reading & changing a collection
        public IEnumerable<Sektion> Sektioner {
            get {
                IEnumerable<Sektion> result = this.sektioner;
                // i don't know, if you need this functionality >>>
                // if ( null == result ) { result = new Sektion[0]; }
                // <<< i don't know, if you need this functionality
                return result;
            }
            set { this.sektion = value; }
        }
    
        //public static void UpdateCache()
        //{
        //// SNIP - getting data, locking etc.
        //Instance.sektioner = newSektioner;
        //// SNIP
        //}
    }
