    class Lazy<T>
      where T: class, new()
    {
      T item;
      public T Item {get{return item!=null?item:item=new T();}}
      public static implicit operator T(Lazy<T> lazy) // possibly make explicit
      {
        return lazy.Item;
      } 
    }
    // option 5
    class Foo
    {
        public Lazy<MyClass> LazyProperty { get; private set; }
        public Foo()
        {
            LazyProperty = new Lazy<MyClass>();
        }
    }
