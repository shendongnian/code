    public abstract class MyClass
    {
        public abstract Type Type { get; }
    }
    
    public class MyClass<T> : MyClass
    {
        public override Type Type
        {
            get { return typeof(T); }
        }
    
        public T Value { get; set; }
    }
    
    // VERY basic illustration of how you might construct a collection
    // of MyClass<T> objects.
    public class MyClassCollection
    {
        private Dictionary<Type, MyClass> _dictionary;
        public MyClassCollection()
        {
            _dictionary = new Dictionary<Type, MyClass>();
        }
        
        public void Put<T>(MyClass<T> item)
        {
            _dictionary[typeof(T)] = item;
        }
        public MyClass<T> Get<T>()
        {
            return _dictionary[typeof(T)] as MyClass<T>;
        }
    }
