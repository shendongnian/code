    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var people = new List<Customer> {
    		
    			new Customer { FirstName = "b", LastName = "b" },
    			new Customer { FirstName = "a", LastName = "c" },
    			new Customer { FirstName = "c", LastName = "a" },
    		};
    		
    		people.Sort((x, y) => x.LastName.CompareTo(y.LastName));
    		foreach(var p in people)
    		{
    			Console.WriteLine($"{p.FirstName} {p.LastName}");
    		}
    	}
    }
    
    public class Customer : IComparable<Customer>
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	
    	public int CompareTo(Customer p)
    	{
    		return this.FirstName.CompareTo(p.FirstName);
    	}
    }
