    public class CollectionFactory
    {
        public CollectionBase<ItemBase> CreateCollection()
        {
            if(someCondition)
            {
                return CreateAdapter(new MyCollection());
            }
            else
            {
                return CreateAdapter(new MyOtherCollection());
            }
        }
        private static CollectionAdapter<T> CreateAdapter<T>(CollectionBase<T> collection) where T : ItemBase, new()
        {
            return new CollectionAdapter<T>(collection);
        }
        private class CollectionAdapter<T> : CollectionBase<ItemBase> where T : ItemBase, new()
        {
            private CollectionBase<T> _collection;
            internal CollectionAdapter(CollectionBase<T> collection)
            {
                _collection = collection;
            }
            // Implement CollectionBase API by passing through to _collection
        }
    }
