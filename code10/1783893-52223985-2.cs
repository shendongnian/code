    public class YourBooks
    {
        private ObservableCollection<int> _myCollection;
        public YourBooks()
        {
            _myCollection = new ObservableCollection<int>();
            _myCollection.Add(4);
            var newBook = new NewBook(this);
        }
        public void addInt(int myint)
        {
            _myCollection.Add(myint);
        }
    }
    public class NewBook
    {
        public YourBooks YourBooks { get; set; }
        public NewBooks(YourBooks yourBooks)
        {
            YourBooks = yourBooks
            addSomething();
        }
        public void addSomething()
        {
            YourBook.addInt(5);
            YourBook.addInt(6);
        }
    }
