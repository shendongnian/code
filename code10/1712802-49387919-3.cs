    public static class TypeStore
    {
        private static Dictionary<string, Type> store;
        private static ReadOnlyDictionary<string, Type> storeReadOnly ;
        
        /// <summary>
        /// Initializes static members of the <see cref="TypeStore"/> class.
        /// </summary>
        static TypeStore()
        {
            store = new Dictionary<string, Type>();
            storeReadOnly = new ReadOnlyDictionary<string, Type>(store);
        }
        /// <summary>
        /// Gets the store.
        /// </summary>
        public static IReadOnlyDictionary<string, Type> Store => storeReadOnly;
        public static void AddTypes()
        {
            // This should be allowed
            TypeStore.store.Add("object", typeof(object));
        }
    }
