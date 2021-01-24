    public class FooStore
    {
        public IList<Foo> List()
        {
            // ...
        }
        public int Add(Foo foo)
        {
            // ...
        }
        public void Update(int id, Foo foo)
        {
            // ...
        }
        public void Update(int id, IDictionary<string, object> fields)
        {
            // ...
        }
        public void Remove(int id)
        {
            // ...
        }
    }
