    private Dictionary<Type, ICollection> registry = new Dictionary<Type, ICollection>();
    // adds a collection of a certain type
    public void Add<T>(T collection) where T: ICollection {
        registry.Add(typeof(T), collection);
    }
    // create an empty collection of type T and add it to registry
    public void InitCollection<T>() where T: ICollection { 
        registry.Add(typeof(T), (ICollection)Activator.CreateInstance(typeof(T)));
    }
    // returns a collection of type T if it has been registered
    public T Set<T>() where T: ICollection {
        return (T)registry[typeof(T)];
    }
