    public void SomeMethod<T>( ) 
        where T : new()
    {
        T s = new T();
        IRepository<T> obj = (IRepository<T>)ServiceLocator.Current.GetInstance(t)
        // ...
    }
