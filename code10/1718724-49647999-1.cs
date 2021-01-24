    class Program
    {
        static void Main()
        {
            List<Pet> Pets = new List<Pet>();    
            Pets.Add(new Dog("Lassie"));
            Pets.Add(new Cat("Garfield"));
            Pets.Add(new Dog("Benji"));
            Pets.Add(new Cat("Tony"));
            Pets.Add(new Dog("Oddie"));
            Pets.Add(new Cat("Felix"));
            
            Call(Pets);
            
            Console.WriteLine();
            
            ListCatsThenDogs(Pets);
        }
        
        static void Call(IEnumerable<Pet> Pets)
        {
            Console.WriteLine("Calling all pets...");
            
            foreach (Pet pet in Pets)
            {
                Console.WriteLine("Come here " + pet.Name);
                pet.Speak(); // using the abstract Speak() method
            }
        }
        
        static void ListCatsThenDogs(IEnumerable<Pet> Pets)
        {
            Console.WriteLine("Listing cats then dogs in alphabetical order...");
            
            foreach(Pet pet in Pets
                .OrderBy(p => p.GetType().FullName) // order by type ("Cat" < "Dog")
                .ThenBy(p => p.Name))               // then by name
            {
                Console.WriteLine(pet.Name);
            }
        }
    }
