    public class Foo
    {
        private static readonly ICollection<string> _collection;
    
        static Foo()
        {
            _collection = new List<string>();
            _collection.Add("One");
            _collection.Add("Two");
        }
    }
