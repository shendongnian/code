    DynamicObject dynamic = new DynamicObject();
    
    IPerson person = null;
    
    // This will return false
    bool isPerson = dynamic.LooksLike<IPerson>();
    
    // Implement IPerson
    dynamic.MixWith(new HasAge(18));
    dynamic.MixWith(new Nameable("Me"));
    
    // Now that it's implemented, this
    // will be true
    isPerson = dynamic.LooksLike<IPerson>();
    
    if (isPerson)
       person = dynamic.CreateDuck<IPerson>();
    
    // This will return "Me"
    string name = person.Name;
    
    // This will return '18'
    int age = person.Age;
