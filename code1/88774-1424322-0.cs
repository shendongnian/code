    public T Foo<T>() {
        if (!typeof(T).IsAssignableFrom(typeof(MyBaseClass))
            || !typeof(T).GetConstructor(...))
            throw new System.NotImplementedException();
        ...
     }
