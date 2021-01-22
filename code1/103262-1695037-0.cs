    public class Decorable
    {
        Dictionary<Type,object> decors = new Dictionary<Type,object>();
        public void AddDecorator<D>(D decor) { decors[typeof(D)] = decor; }
        public D GetDecorator<D>()
        {
            object value;
            if (decors.TryGetValue(typeof(D), out value))
                return (D)value;
            else
                return default(D);
        }
    
    }
    public class Decorator<T> where T: class, Decorable
    {
        private readonly T _instance;
        public Decorator(T instance)
        {
            _instance = instance;
            instance.AddDecorator(this);
        }
        public T Instance
        {
            get { return _instance; }
        }
        public object AdditionalInformation { get; set; }
    }
    // use it like this
    Decorator<MyClass> myDecor = myObj.GetDecorator<Decorator<MyClass>>();
