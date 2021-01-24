    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Item { 
        public string Name { get; set; }
        public object Value { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var items = new List<Item>();
    		items.Add(new Item(){
    			Name = "test",
    			Value = 2
    		});
    		items.Add(new Item(){
    			Name = "id",
    			Value = 0
    		});
    		
    		items.Where(i => i.Name == "id").ToList().ForEach(i => i.Value = 1);
    		Console.WriteLine(items[1].Name + " : " + items[1].Value);
    	}
    }
