    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var carOne = new Car()
    		{color = "Yellow", year = 2008, index = 1, name = "Car One"};
    		var carTwo = new Car()
    		{color = "Yellow", year = 2008, index = 2, name = "Car Two"};
    		var carThree = new Car()
    		{color = "Yellow", year = 2009, index = 3, name = "Car Three"};
    		var carFour = new Car()
    		{color = "Red", year = 2012, index = 4, name = "Car Four"};
    		var carFive = new Car()
    		{color = "Red", year = 2012, index = 5, name = "Car Five"};
    		
    		var lstCars = new List<Car>() {carOne, carTwo, carThree, carFour, carFive};
    		
    		
    		var groupCars = lstCars.GroupBy(x => new {x.color, x.year}).Select(t => new{Color = t.Key.color, Year = t.Key.year, ListCount = t.Count(), Names = t.Select(z => z.name).ToList()}).ToList();
    		
    		
    		foreach (var item in groupCars)
    		{
    			Console.WriteLine("{0} \t List Count - {1}", item.Color, item.ListCount);
    			Console.WriteLine("\t{0}", item.Year);
    			foreach (var name in item.Names)
    			{
    				Console.WriteLine("\t\t" + name);
    			}
    
    			Console.WriteLine("\n");
    		}
    	}
    }
    
    public class Car
    {
    	public string color;
    	public int year;
    	public int index;
    	public string name;
    }
