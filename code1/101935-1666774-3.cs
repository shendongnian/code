    public void PrintType(IAnimal animal)
    {   
        Console.WriteLine(typeof(animal));
        //or
        Console.WriteLine(animal.GetType());
    }
