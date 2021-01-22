    public class MyCollection : Collection<int>
    {
        public MyCollection()
        {
        }
        public MyCollection(IList<int> list)
            : base(list)
        {
        }
        protected override void ClearItems()
        {
            // TODO: validate here if necessary
            bool canClearItems = ...;
            if (!canClearItems)
                throw new InvalidOperationException("The collection cannot be cleared while _____.");
            base.ClearItems();
        }
        protected override void RemoveItem(int index)
        {
            // TODO: validate here if necessary
            bool canRemoveItem = ...;
            if (!canRemoveItem)
                throw new InvalidOperationException("The item cannot be removed while _____.");
            base.RemoveItem(index);
        }
    }
