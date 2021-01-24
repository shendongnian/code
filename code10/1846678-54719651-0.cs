    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
            // Create some sample records
    		var persons = new List<Person>(){
    			new Person(){Id = 1, Name = "Bob", Age = 30},
    			new Person(){Id = 2, Name = "Jane", Age = 31},
    			new Person(){Id = 3, Name = "Mary", Age = 32}
    		};
    		
            // Use Reflection to retrieve public properties
    		var properties = typeof(Person).GetProperties();
    
            // Create a list to store the dictionaries		
    		var listOfDictionary = new List<Dictionary<string, string>>();
    		
            // For each person class
    		foreach(var person in persons){
    		    // Create a new dictionary
    			var dict = new Dictionary<string,string>();
    			// For each property
    			foreach(var prop in properties){
    			    // Add the name and value of the property to the dictionary
    				dict.Add(prop.Name, prop.GetValue(person).ToString());
    				
    			}
    			// Add new dictionary to our list
    			listOfDictionary.Add(dict);
    			
    		}
    		
    		
    		// Check the contents of our list
    		foreach(var dict in listOfDictionary){		
    			Console.WriteLine(string.Join(",", dict.Keys));
    			Console.WriteLine(string.Join(",", dict.Values));
    		}
    		
    	}
    	
    	public class Person 
    	{
    		public int Id { get; set; }
    		public string Name { get; set; }
    		public int Age { get; set; }
    	}
    }
