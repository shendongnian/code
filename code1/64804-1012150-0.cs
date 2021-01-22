    public void DoThingWithCat(Cat snuggles)
    {
        snuggles.Meow();
        DoThingWithAnimal(snuggles); // this is always OK, because we know 
                                     // the type of snuggles, and we know 
                                     // snuggles is an animal
    }
