    using System;
    
    class Program
    {
        enum PetType
        {
    	None,
    	Cat = 1,
    	Dog = 2
        }
    
        static void Main()
        {
    	// Possible user input:
    	string value = "Dog";
    
    	// Try to convert the string to an enum:
    	PetType pet = (PetType)Enum.Parse(typeof(PetType), value);
    
    	// See if the conversion succeeded:
    	if (pet == PetType.Dog)
    	{
    	    Console.WriteLine("Equals dog.");
    	}
        }
    }
    -------------
    Output
    
    Equals dog.
