    static void FeedAnimal(Animal a)
    {
        Type type = a.GetType();
        
        if (type == typeof(Dog))
        {
            Console.WriteLine("Fed a dog.");
        }
        else if (type == typeof(Monkey))
        {
            Console.WriteLine("Fed a monkey.");
        }
        else
        {
            Console.WriteLine("I don't know how to feed a " + type.Name + ".");
        }      
    }
