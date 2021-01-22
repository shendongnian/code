    class Animal { } 
    class Dog : Animal { }
    void PrintTypes(Animal a) { 
        Console.WriteLine(a.GetType() == typeof(Animal)); // false 
        Console.WriteLine(a is Animal);                   // true 
        Console.WriteLine(a.GetType() == typeof(Dog));    // true
        Console.WriteLine(a is Dog);                      // true 
    }
    Dog spot = new Dog(); 
    PrintTypes(spot);
