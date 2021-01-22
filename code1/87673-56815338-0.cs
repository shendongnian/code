    public class MyClass
    {
        public class MyStuff
        {
            string foo { get; set; }
        }
        private ObservableCollection<MyStuff> _collection;
        public ObservableCollection<MyStuff> Items { get { return _collection; } }
        public MyClass()
        {
            _collection = new ObservableCollection<MyStuff>();
            this.LoadMyCollectionByRef<MyStuff>(ref _collection);
        }
        public void LoadMyCollectionByRef<T>(ref ObservableCollection<T> objects_collection)
        {
            // Load refered collection
        }
    }
