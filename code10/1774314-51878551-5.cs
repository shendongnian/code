    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat();
            cat1.SetWeight(50.5f);
    
            Cat cat2 = new Cat();
            cat2.SetWeight(67.7f);
    
            Cat  cat3 = new Cat();
            cat3.SetWeight(54.3f);
    
            Zoo z = new Zoo();
            // Create new Zoo with arcats of length 3
            // z.CreateZoo(21);
            z.CreateZoo(3);
            // Add the three Cats to the Zoo
            z.AddCat(0, cat1);
            z.AddCat(1, cat2);
            z.AddCat(2, cat3);
    
            Console.WriteLine("Checking if Zoo is full: " + z.IsZooFull()); // false
            Console.WriteLine("Average weight of Cats in Zoo: " + z.GetAvgWeight());
        }
    }
