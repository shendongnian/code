    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var people = new [] {
    			new Person("Caleb"),
    			new Person("Martin"),
    			new Person("Shaun"),
    			new Person("Nechemia")
    		};
    		
    		var result = Array.Find(people, person => person.Name == "Caleb");
    		Console.WriteLine(result.Name);
    	}
    }
    
    public struct Person
    {
    	public readonly string Name;
    	
    	public Person(string name)
    	{
    		Name = name;
    	}
    }
