    var myCollection = new KeyedByTypeCollection<A>();
    myCollection.Add(new A());
    myCollection.Add(new B());
    
    myCollection.TryGetValue(out B b);
    b = myCollection.ValueOrDefault<B,A>();
