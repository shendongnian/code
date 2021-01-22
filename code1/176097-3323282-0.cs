    var myKeyedByIdCollection =
        new ProjectionKeyedCollection<int, MyCustomType>(i => i.Id);
    // ...
    public class ProjectionKeyedCollection<TKey, TItem>
        : KeyedCollection<TKey, TItem>
    {
        private readonly Func<TItem, TKey> _keySelector;
        public ProjectionKeyedCollection(Func<TItem, TKey> keySelector)
        {
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            _keySelector = keySelector;
        }
        protected override TKey GetKeyForItem(TItem item)
        {
            return _keySelector(item);
        }
    }
