    static void FeedAnimal(Animal a)
    {
        if (a is Dog)
        {
            Console.WriteLine("Fed a dog.");
        }
        else if (a is Monkey)
        {
            Console.WriteLine("Fed a monkey.");
        }
        else
        {
            Console.WriteLine("I don't know how to feed a " + a.GetType().Name + ".");
        }      
    }
