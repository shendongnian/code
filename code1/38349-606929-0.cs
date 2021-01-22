    public class Pet
    {
         public int PetID { get; set; }
         public string Name { get; set; }
         public int Age { get; set; }
         public decimal Weight { get; set; }
    }
    
    List<Pet> pets = new List<Pet>() 
    { 
        new Pet {PetID = 1, Age = 5, Name = "Bob", Weight = 4M },
        new Pet {PetID = 2, Age = 5, Name = "Brad", Weight = 3M },
        new Pet {PetID = 3, Age = 2, Name = "Troy", Weight = 1M },
        new Pet {PetID = 4, Age = 2, Name = "Dave", Weight = 2M },
        new Pet {PetID = 5, Age = 2, Name = "Simon", Weight = 3M }
    };
    
    var fatPetsByAge = from pet in pets
                       group pet by pet.Age into petsByAge
                       select new
                       {
                           Age = petsByAge.Key,
                           FatPet = petsByAge.FirstOrDefault(
                                    f => f.Weight == petsByAge.Max(m => m.Weight))
                       };
    
    foreach (var fatty in fatPetsByAge)
    {
        Console.WriteLine("PetID: {0}, Age: {1} Name: {2} Weight: {3}",
            fatty.FatPet.PetID,
            fatty.FatPet.Age,
            fatty.FatPet.Name,
            fatty.FatPet.Weight);
    }
