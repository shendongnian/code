    using System;
    
    abstract class Pet { }
    
    class Dog : Pet, IPet
    {
    	public String Name { get; set; }
    	public Int32 Age { get; set; }
    }
    
    class Cat : Pet, IPet
    {
    	public String Name { get; set; }
    	public Int32 Age { get; set; }
    }
    
    interface IPet
    {
    	String Name { get; set; }
    	Int32 Age { get; set; }
    }
    
    static class PetUtils
    {
    	public static void Print(this IPet pet)
    	{
    		Console.WriteLine(pet.Name + " is " + pet.Age);
    	}
    }
