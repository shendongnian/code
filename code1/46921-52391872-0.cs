    SesameStreetCharacter puppet = new SesameStreetCharacter() { Name = "Elmo", Age = 5 };
    
    // creates new object of type "RealPerson" and assigns any matching property 
    // values from the puppet object 
    // (this method requires that "RealPerson" have a parameterless constructor )
    RealPerson person = ObjectMapper.MapToNewObject<RealPerson>(puppet);
    // OR
    // create the person object on our own 
    // (so RealPerson can have any constructor type that it wants)
    SesameStreetCharacter puppet = new SesameStreetCharacter() { Name = "Elmo", Age = 5 };
    RealPerson person = new RealPerson("tall") {Name = "Steve"};
    
    // maps and overwrites any matching property values from 
    // the puppet object to the person object so now our person's age will get set to 5 and
    // the name "Steve" will get overwritten with "Elmo" in this example
    ObjectMapper.MapToExistingObject(puppet, person);
