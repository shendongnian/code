    public class ReadOnlyDictionary<T, U>
    {
        private IDictionary<T, U> BackingStore;
    
        public ReadOnlyDictionary<T, U>(IDictionary<T, U> baseDictionary) {
            this.BackingStore = baseDictionary;
        }
    
        public U this[T index] { get { return BackingStore[index]; } }
       
        // provide whatever other methods and/or interfaces you need
    }
