    public class MyList<MyType>
    {
        private List<MyType> items;
        public MyList()
        {
        }
        public IEnumerable Items { get { return items.AsEnumerable(); } }
        public Add(MyType item)
        {
            // do internal processing
            items.Add(item);
        }
    }
