    Mutable[] arrayOfMutables = new Mutable[1];
    arrayOfMutables[0] = new Mutable(5);
    
    // Now we actually accessing reference to the first element
    // without making any additional copy
    arrayOfMutables[0].IncrementI();
    
    //Prints 6!!
    Console.WriteLine(arrayOfMutables[0].I);
    
    // Every array implements IList<T> interface
    IList<Mutable> listOfMutables = arrayOfMutables;
    
    // But accessing values through this interface lead
    // to different behavior: IList indexer returns a copy
    // instead of an managed reference
    listOfMutables[0].IncrementI(); // Should change I to 7
    
    // Nope! we still have 6, because previous line of code
    // mutate a copy instead of a list value
    Console.WriteLine(listOfMutables[0].I);
