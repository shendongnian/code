    // Let's define a collection item type
    class Item
    {
        public Item ( string text, DateTime date )
        {
            SomeText = text;
            SomeDate = date;
        }
        public string SomeText { get; private set; }
        public DateTime SomeDate { get; private set; }
    }
    // A simple viewmodel
    class SomeViewModel : ViewModelBase
    {
        public SomeViewModel ( )
        {
            Items.Add ( new Item ( "Item A", DateTime.MinValue ) );
            Items.Add ( new Item ( "Item B", DateTime.UtcNow   ) );
            Items.Add ( new Item ( "Item C", DateTime.MaxValue ) );
        }
        public ObservableCollection<Item> Items { get; }
         = new ObservableCollection<Item> ( );
    }
