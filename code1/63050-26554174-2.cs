    void Main()
    {
        Animal rover  = Animal.bulldog;
        Animal rhoda = Animal.greyhound;
        Animal rafter = Animal.greyhound;
        
        Animal felix = Animal.persian;
        Animal zorrow = Animal.burmese;
        
        Animal rango = Animal.chameleon;
        
        if( rover.IsDog() )
            Console.WriteLine("rover is a dog");
        else
            Console.WriteLine("rover is not a dog?!");
        
        if( rover == rhoda )
            Console.WriteLine("rover and rhonda are the same type");
            
        if( rover.AnimalType() == rhoda.AnimalType() )
            Console.WriteLine("rover and rhonda are related");
        
        if( rhoda == rafter )
            Console.WriteLine("rhonda and rafter are the same type");
            
        if( rango.IsReptile() )
            Console.WriteLine("rango is a reptile");
        
        Console.WriteLine(rover.ToString<AnimalAttribute>());
    }
