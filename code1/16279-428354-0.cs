    public class Parent<T>
        where T : Child<T>
    {
        public Parent() { }
        public T Get()
        {
            return Activator.CreateInstance(typeof(T), new object[] { this }) as T;
        }
    }
    
    public class Child<T>
        where T : Child<T>
    {
        Parent<T> _parent;
    
        public Parent<T> Parent { get { return _parent; } }
    
        public Child(Parent<T> parent)
        {
            _parent = parent;
        }
    }
    
    
    public class ItemCollection : Parent<Item>
    {
    
    }
    
    public class Item : Child<Item>
    {
        public Item(Parent<Item> parent)
            : base(parent)
        {
        }
    }
