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
    public class StringStorage
    {
        private string _item;
        public void StoreItem(string item)
        {
            _item = item;
        }
        public string RetrieveItem()
        {
            return _item;
        }
    }
