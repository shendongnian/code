    public class MyObject
    {
        private IList<AnotherObject> items;
        public List<AnotherObject> Items()
        {
            return (List<AnotherObject>)items;
        }
    }
