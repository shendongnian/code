    public void DoSomethingDifferent(object anObject)
    {
        DoThingWithAnimal(anObject); // this may or may not work, 
                                     // depending on the type passed in, 
                                     // this is a recipe for disaster, 
                                     // because may not be an Animal, 
                                     // it could be a Tree.
    }
