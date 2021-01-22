    public class MyControl : UserControl
    {
        private List<MyItem> _items = new List<MyItem>();
        public List<MyItem> Items
        {
             get { return _items; }
             set { _items = value; }
        }
     }
