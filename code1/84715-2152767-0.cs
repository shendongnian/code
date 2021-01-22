    class FooRepository<T>
    where T: class, IFoo, new() 
    {
        // ...
        public void Add(T foo) 
        {
            db.Foos.InsertOnSubmit(foo);    
        }
    }
