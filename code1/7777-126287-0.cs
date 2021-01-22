        class MyEnum : IEnumerable<SomeObject>
    {
        private List<SomeObject> _myList = new List<SomeObject>();
        public IEnumerator<SomeObject> GetEnumerator()
        {
            // Create a read-only copy of the list.
            ReadOnlyCollection<CustomDevice> items = new ReadOnlyCollection<CustomDevice>(_myList);
            return items.GetEnumerator();
        }
    }
