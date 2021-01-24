    var myCollection = new KeyedByTypeCollection<A>();
    myCollection.Add(new A());
    myCollection.Add(new B());
    
    myCollection.TryGetValue(out B b); // <-- Nice! :)
    b = myCollection.ValueOrDefault<B,A>();  // <-- Ugly :(
