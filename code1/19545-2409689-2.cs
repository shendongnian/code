    [Serializable, ComVisible(true)]
    public abstract class DictionaryBase : IDictionary, ICollection, IEnumerable
    {
        // Fields
        private Hashtable hashtable;
    
        // Methods
        protected DictionaryBase();
        public void Clear();
    .
    .
    .
    }
    Take note of these lines
    // Fields
    private Hashtable hashtable;
