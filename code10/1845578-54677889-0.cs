    interface IDummy
    {}
    class FooBar<T> where T : class
    {
        void Bar(T foo)
        {
           if (foo is IEnumerable<IDummy> enumerableFoo)
              foreach (var item in enumerableFoo)
                 B(item);
           else if(foo is IDummy)
              B(foo);                      
        }  
        void B(T item)
        {
        }
    }
