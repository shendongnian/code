    using System;
    using System.Collections.Generic;
    
    
    public class Program
    {
    	public class Location {}
    	
    	public interface ISwimmer{
    	  void SwimTo(Location destination);
    	}
    	
    	public class Animal {} // whatever base class properties you need
    	
    	public class Duck : Animal, ISwimmer
    	{
    		public void SwimTo(Location destination)
    		{
    			Console.WriteLine("Implement duck's swim logic");			
    		}
    	}
    	
    	public class Fish : Animal, ISwimmer
    	{
    		public void SwimTo(Location destination)
    		{
    			Console.WriteLine("Implement fish's swim logic");
    		}
    	}
    	
    	public class Giraffe : Animal {}
    	
    	
    	public static void Main()
    	{
    		List<Animal> animals = new List<Animal>
    		{
    			new Duck(),
    			new Fish(),
    			new Giraffe()
    		};	
    	
    		foreach (Animal animal in animals)
    		{
    			ISwimmer swimmer = animal as ISwimmer;			
    			if (swimmer==null) continue; // this one can't swim
    			swimmer.SwimTo(new Location());
    		}
    	}
    }
