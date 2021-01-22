    using System;
    
    [Flags] public enum Pet {
       None = 0,
       Dog = 1,
       Cat = 2,
       Bird = 4,
       Rabbit = 8,
       Other = 16
    }
    
    public class Example
    {
       public static void Main()
       {
          // Define three families: one without pets, one with dog + cat and one with a dog only
          Pet[] petsInFamilies = { Pet.None, Pet.Dog | Pet.Cat, Pet.Dog };
          int familiesWithoutPets = 0;
          int familiesWithDog = 0;
    
          foreach (Pet petsInFamily in petsInFamilies)
          {
             // Count families that have no pets. 
             if (petsInFamily.Equals(Pet.None))
                familiesWithoutPets++;
             // Of families with pets, count families that have a dog. 
             else if (petsInFamily.HasFlag(Pet.Dog))
                familiesWithDog++;
          }
          Console.WriteLine("{0} of {1} families in the sample have no pets.", 
                            familiesWithoutPets, petsInFamilies.Length);   
          Console.WriteLine("{0} of {1} families in the sample have a dog.", 
                            familiesWithDog, petsInFamilies.Length);   
       }
    }
