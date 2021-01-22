    void ReactSpecialization(Animal me, Animal other) 
    { 
        Console.WriteLine("{0} is not interested in {1}.", me, other); 
    }
    void ReactSpecialization(Cat me, Dog other) 
    { 
        Console.WriteLine("Cat runs away from dog."); 
    }
    void ReactSpecialization(Cat me, Mouse other) 
    { 
        Console.WriteLine("Cat chases mouse."); 
    }
    void ReactSpecialization(Dog me, Cat other) 
    { 
        Console.WriteLine("Dog chases cat."); 
    }
