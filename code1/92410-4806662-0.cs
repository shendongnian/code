    public class KeyedCollection<TItem> : System.Collections.ObjectModel.KeyedCollection<TItem, TItem>
        where TItem : class
    {
        public KeyedCollection() : base()
        {
        }
    	
        public KeyedCollection(IEqualityComparer<TItem> comparer) : base(comparer)
        {
        }
    
        protected override TItem GetKeyForItem(TItem item)
        {
            return item;
        }
    }
    
    public class KeyedObjectCollection<TKey, TItem> : System.Collections.ObjectModel.KeyedCollection<TKey, TItem>
        where TItem : class, IKeyedObject<TKey>
        where TKey : struct
    {
        public KeyedCollection() : base()
        {
        }
    
        protected override TItem GetKeyForItem(TItem item)
        {
            return item.Key;
        }
    }
    
    ///<summary>
    /// I almost always implement this explicitly so the only
    /// classes that have access without some rigmarole
    /// are generic collections built to be aware that an object
    /// is keyed.
    ///</summary>
    public interface IKeyedObject<TKey>
    {
        TKey Key { get; }
    }
