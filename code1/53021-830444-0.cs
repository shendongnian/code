    public class MyObject
    {
        private IList<AnotherObject> items;
        public List<AnotherObject> Items
        {
            return new List<AnotherObject>items.Cast<AnotherObject>());
        }
        // or, to prevent modifying the list
        public IEnumerable<AnotherObject> Items
        {
            return items.Cast<AnotherObject>();
        }
    }
