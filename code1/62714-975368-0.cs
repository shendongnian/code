    public class Items<TItem>
    {
        private IList<TItem> _items = new List<TItem>();
        public IList<TItem> Collection
        {
            get { return _items; }
        }
        // ...
     }
