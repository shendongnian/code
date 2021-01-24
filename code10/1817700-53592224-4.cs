    public class BookStorage
    {
        private Book _item;
        public void StoreItem(Book item)
        {
            _item = item;
        }
        public Book RetrieveItem()
        {
            return _item;
        }
    }
