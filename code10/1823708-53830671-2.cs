    /* Null object pattern implementation:
     */
    using System;
    // Animal interface is the key to compatibility for Animal implementations below.
    interface IAnimal
    {
	    void MakeSound();
    }
    // Animal is the base case.
    abstract class Animal : IAnimal
    {
	    // A shared instance that can be used for comparisons
	    public static readonly IAnimal Null = new NullAnimal();
	
	    // The Null Case: this NullAnimal class should be used in place of C# null keyword.
	    private class NullAnimal : Animal
    	{
		    public override void MakeSound()
		    {
		    	// Purposefully provides no behaviour.
		    }
	    }
	    public abstract void MakeSound();
    }
    // Dog is a real animal.
    class Dog : IAnimal
    {
    	public void MakeSound()
	    {
	    	Console.WriteLine("Woof!");
	    }
    }
    /* =========================
     * Simplistic usage example in a Main entry point.
     */
    static class Program
    {
    	static void Main()
    	{
	    	IAnimal dog = new Dog();
	    	dog.MakeSound(); // outputs "Woof!"
	    	/* Instead of using C# null, use the Animal.Null instance.
             * This example is simplistic but conveys the idea that if the         Animal.Null instance is used then the program
             * will never experience a .NET System.NullReferenceException at runtime, unlike if C# null were used.
             */
	    	IAnimal unknown = Animal.Null;  //<< replaces: IAnimal unknown = null;
		unknown.MakeSound(); // outputs nothing, but does not throw a runtime exception        
	    }
    }
