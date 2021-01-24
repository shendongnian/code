    public interface IValidatable
    {
        public bool IsValid();
    }
    public class Storage<T> : T extends IValidatable
    {
        private T _item;
        public void StoreItem(T item)
        {
           if (item.IsValid()) 
           {
                _item = item;
           }
        }
        public T RetrieveItem()
        {
            return _item;
        }
    }
