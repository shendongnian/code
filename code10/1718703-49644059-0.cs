     private static void ListCatsThenDogsInAlphabeticalOrder(IEnumerable<Pet> pets)
        {
            Console.WriteLine("\nPets");
            Console.WriteLine("----------");
    
            // Use a linq expression or extension methods to sort the pets first by type (cats first, dogs second),
            // and then by alphabetically by their names.  Print the sorted list.
    
            foreach (Pet pet in pets)
                Console.WriteLine(pet.Name);
    
            Console.WriteLine("----------");
        } 
